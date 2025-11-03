using barberBoss.Communication.Response.Billings;
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using Mapster;

namespace barberBoss.Application.UseCases.BillingsUseCase.GetByID;

public class GetByIdBillingUseCase : IGetByIdBillingUseCase
{
    private readonly IBillingQuery _billingQuery;
    public GetByIdBillingUseCase(IBillingQuery billingQuery)
    {
        _billingQuery = billingQuery;
    }
    public async Task<ResponseBillings> GetByIdBilling(int id)
    {
        var getbyId = await _billingQuery.GetBillingById(id);
        if (getbyId is null)
        {
            throw new NotFoundSystem("Não existe faturamento com id fornecido !");
        }

        var response = getbyId.Adapt<ResponseBillings>();
        return response;
    }
}

    
