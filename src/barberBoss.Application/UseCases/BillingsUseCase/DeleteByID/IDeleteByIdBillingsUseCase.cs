using barberBoss.Application.ScanAssembly;

namespace barberBoss.Application.UseCases.BillingsUseCase.DeleteByID;

public interface IDeleteByIdBillingsUseCase : IScanGeneric
{
    Task DeleteById(int id, CancellationToken cancellationToken);
}
