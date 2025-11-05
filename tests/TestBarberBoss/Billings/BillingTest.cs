using barberBoss.Application.UseCases.BillingsUseCase.Validation;
using barberBoss.Communication.Enum;
using barberBoss.Communication.Request.Billings;
using Shouldly;
using UnitFakerTests.Request;

namespace TestBarberBoss.Billings;

public class BillingTest
{

    [Fact]
    public void RequestSucess()
    {
        var validator = GetValidator();
        var builder = BillingFaker.FakerBilling();
        builder.ServiceName = "Corte de Cabelo";
        builder.Amount = 35.00m;

        var result = validator.Validate(builder);
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Request_Errors()
    {
        var validator = GetValidator();
        var builder = GetRequestBilling();

        var result = validator.Validate(builder);
        result.IsValid.ShouldBeFalse();
    }

      

    private ValidationRegisterBillingsUseCase GetValidator()
    {
        return new ValidationRegisterBillingsUseCase();
    }

    //A requisição tera retorno null/0.
    private RequestBillings GetRequestBilling()
    {
        return new RequestBillings();
    }
}
