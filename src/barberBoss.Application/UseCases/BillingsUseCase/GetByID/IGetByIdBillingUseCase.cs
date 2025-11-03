using barberBoss.Application.ScanAssembly;
using barberBoss.Communication.Response.Billings;

namespace barberBoss.Application.UseCases.BillingsUseCase.GetByID;

public interface IGetByIdBillingUseCase : IScanGeneric
{
    Task<ResponseBillings> GetByIdBilling(int id);
}
