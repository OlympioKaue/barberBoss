using barberBoss.Application.ScanAssembly;
using barberBoss.Communication.Request.Billings;

namespace barberBoss.Application.UseCases.BillingsUseCase.Update;

public interface IUpdateByIdBillingUseCase : IScanGeneric
{
    Task UpdateById(int id, RequestBillings request, CancellationToken cancellationToken);
}
