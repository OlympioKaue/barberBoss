using barberBoss.Application.ScanAssembly;
using barberBoss.Communication.Response.Billings;

namespace barberBoss.Application.UseCases.BillingsUseCase.Get;

public interface IGetBillingsUseCase : IScanGeneric
{
    Task<ResponseListBilling> GetBillings(int numberPage, int numberSize);
}
