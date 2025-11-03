using barberBoss.Communication.Response.Billings;
using barberBoss.Domain.Entities;
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using Mapster;

namespace barberBoss.Application.UseCases.BillingsUseCase.Get;

public class GetBillingsUseCase : IGetBillingsUseCase
{
    private readonly IBillingQuery _billingQuery;
    public GetBillingsUseCase(IBillingQuery billingQuery)
    {
        _billingQuery = billingQuery;
    }
    public async Task<ResponseListBilling> GetBillings(int numberPage, int numberSize)
    {
        if(numberPage <= 0 || numberSize <= 0)
        {
            throw new NotFoundSystem("O numero de paginas e tamanho devem ser maior que 0");
        }

        var getBilling = await _billingQuery.GetBilling(numberPage, numberSize);
        if (getBilling is null || !getBilling.Any())
            throw new NotFoundSystem("Nenhum faturamento encontrado !");

        var response = getBilling.Adapt<List<ResponseSummarizedBilling>>();
        return new ResponseListBilling
        {
            Billings = response,
        };
    }
}
