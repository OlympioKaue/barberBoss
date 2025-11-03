using barberBoss.Communication.Request.Billings;
using FluentValidation;

namespace barberBoss.Application.UseCases.BillingsUseCase.Validation;

public class ValidationRegisterBillingsUseCase : AbstractValidator<RequestBillings>
{
    public ValidationRegisterBillingsUseCase()
    {
        RuleFor(x => x.BarberName)
            .NotEmpty().WithMessage("O nome do profissional é obrigatório");
        //.MinimumLength(4).WithMessage("O nome do profissional deve ser no minimo de 4 caractere");

        RuleFor(x => x.ClientName).NotEmpty().WithMessage("O nome do cliente é obrigatório");
        //.MinimumLength(4).WithMessage("O nome do cliente deve ser no minimo de 4 caractere");

        RuleFor(x => x.ServiceName).NotEmpty().WithMessage("O nome do serviço é obrigatório");
             //.MinimumLength(4).WithMessage("O nome do serviço deve ser no minimo de 4 caractere");

        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("O valor deve ser maior ou igual a 0");

        RuleFor(x => x.PaymentMethod).IsInEnum().WithMessage("Números aceitos (1 - DINHEIRO) / (2 - DÉBITO) / (3 - CRÉDITO) / (4 - PIX)");

    }
}
