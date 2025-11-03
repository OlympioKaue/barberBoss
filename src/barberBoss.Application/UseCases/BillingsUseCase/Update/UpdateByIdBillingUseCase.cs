using barberBoss.Application.UseCases.BillingsUseCase.Validation;
using barberBoss.Communication.Enum;
using barberBoss.Communication.Request.Billings;
using barberBoss.Domain.Entities;
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using Mapster;

namespace barberBoss.Application.UseCases.BillingsUseCase.Update;

public class UpdateByIdBillingUseCase : IUpdateByIdBillingUseCase
{
    private readonly IBillingQuery _billingQuery;
    private readonly IUnitOfWork _unit;
    private readonly IBillingCommand _billingCommand;
    public UpdateByIdBillingUseCase(IBillingQuery billingQuery, IBillingCommand billingCommand, IUnitOfWork unit)
    {
        _billingQuery = billingQuery;
        _billingCommand = billingCommand;
        _unit = unit;
    }
    public async Task UpdateById(int id, RequestBillings request, CancellationToken cancellationToken)
    {
        Validate(request);

        var getResult = await _billingQuery.GetBillingById(id);
        if (getResult is null)
            throw new NotFoundSystem("Não existe faturamentos vinculado a esse id");

        AssignsDefaultValues(request);
        request.Adapt(getResult);

        SetBillingStatusAndCreatedAt(getResult);
        _billingCommand.Update(getResult, cancellationToken);
        await _unit.SaveChanges(cancellationToken);

    }
    private void Validate(RequestBillings request)
    {
        var validation = new ValidationUpdateBillingsUseCase();
        var result = validation.Validate(request);

        if (result.IsValid is false)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new OnExceptionSystem(errors);
        }

    }
    //Valores 0 atribui o cancelamento
    //Valores padrão como nullo ou 1(enum), passar o cancelamento.
    private static void SetBillingStatusAndCreatedAt(Billing billing)
    {
        billing.UpdateAt = DateTime.Now;

        if (billing.Amount <= 0 || billing.PaymentMethod is PaymentMethod.NoTransaction)
        {
            billing.Status = Status.Canceled;
            billing.PaymentMethod = PaymentMethod.NoTransaction;
            billing.Amount = 0;
        }
        else
        {
            billing.Status = Status.Paid;
        }
    }

    //Atribuição de valores padrão
    //Caso não atualize os valores de referência passe o null
    //Valores nullos o mapeamento é ignorado
    private static void AssignsDefaultValues(RequestBillings request)
    {
        if (request.BarberName is "string") request.BarberName = null!;

        if (request.ClientName is "string") request.ClientName = null!;

        if (request.ServiceName is "string") request.ServiceName = null!;
    }
}