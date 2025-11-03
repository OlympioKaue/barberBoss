using barberBoss.Communication.Request.Billings;
using FluentValidation;

namespace barberBoss.Application.UseCases.BillingsUseCase.Validation;

public class ValidationUpdateBillingsUseCase : AbstractValidator<RequestBillings>
{
    public ValidationUpdateBillingsUseCase()
    {

        RuleFor(x => x.BarberName)
            .NotEmpty()
            .When(x => x.BarberName != null)
            .WithMessage("O nome do barbeiro não pode estar vazio.");

        RuleFor(x => x.ClientName)
            .NotEmpty()
            .When(x => x.ClientName != null)
            .WithMessage("O nome do cliente não pode estar vazio.");

        RuleFor(x => x.ServiceName)
            .NotEmpty()
            .When(x => x.ServiceName != null)
            .WithMessage("O nome do serviço não pode estar vazio.");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O valor tem que ser igual ou maior que 0.");

        RuleFor(x => x.PaymentMethod)
            .IsInEnum()
            .WithMessage("Números aceitos (1 - DINHEIRO) / (2 - DÉBITO) / (3 - CRÉDITO) / (4 - PIX)");
    }
}
