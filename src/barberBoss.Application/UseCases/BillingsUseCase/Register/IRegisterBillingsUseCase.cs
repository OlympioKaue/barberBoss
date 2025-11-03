using barberBoss.Application.ScanAssembly;
using barberBoss.Communication.Request.Billings;
using barberBoss.Communication.Response.Billings;

namespace barberBoss.Application.UseCases.BillingsUseCase.Register;

public interface IRegisterBillingsUseCase : IScanGeneric
{
    public Task<ResponseRegisterBilling> RegisterExecute(CancellationToken cancellationToken, RequestBillings request);
}


