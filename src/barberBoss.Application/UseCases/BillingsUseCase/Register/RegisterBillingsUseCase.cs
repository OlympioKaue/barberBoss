using barberBoss.Application.UseCases.BillingsUseCase.Validation;
using barberBoss.Communication.Enum;
using barberBoss.Communication.Request.Billings;
using barberBoss.Communication.Response.Billings;
using barberBoss.Domain.Entities;
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using FluentValidation.Results;
using Mapster;

namespace barberBoss.Application.UseCases.BillingsUseCase.Register;

public class RegisterBillingsUseCase : IRegisterBillingsUseCase
{
    private readonly IBillingCommand _billingCommand;
    private readonly IBillingQuery _billingQuery;
    private readonly IUnitOfWork _save;
    public RegisterBillingsUseCase(
        IBillingCommand billingCommand,
        IBillingQuery billingQuery,
        IUnitOfWork save)
    {
        _billingCommand = billingCommand;
        _billingQuery = billingQuery;
        _save = save;
    }

    public async Task<ResponseRegisterBilling> RegisterExecute(CancellationToken cancellationToken, RequestBillings request)
    {
        Validate(request);

        var billingEntity = request.Adapt<Billing>();
        SetBillingStatusAndCreatedAt(billingEntity);

        await _billingCommand.AddBilling(billingEntity, cancellationToken);
        await _save.SaveChanges(cancellationToken);

        return new ResponseRegisterBilling(message: "Sucessful registration");
    }
    private static void Validate(RequestBillings request)
    {
        var validation = new ValidationRegisterBillingsUseCase();
        var result = validation.Validate(request);
        AddBusinessRulesValidation(request, result);

        if (result.IsValid is false)
        {
            var errosMessage = result.Errors.Select(ep => ep.ErrorMessage).ToList();
            throw new OnExceptionSystem(errosMessage);
        }
    }

    private static void AddBusinessRulesValidation(RequestBillings request, ValidationResult result)
    {
        if (request.BarberName.Length <= 4)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "O campo BarberName deve conter no mínimo 4 caractere"));
        }
        if (request.ServiceName.Length <= 4)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "O campo ClientName deve conter no mínimo 4 caractere"));
        }
    }

    private static void SetBillingStatusAndCreatedAt(Billing billing)
    {
        billing.CreatedAt = DateTime.Now;

        if (billing.Amount <= 0)
        {
            billing.Status = Status.Canceled;
            billing.PaymentMethod = PaymentMethod.NoTransaction;
        }
        else
        {
            billing.Status = Status.Paid;
        }
    }
}
