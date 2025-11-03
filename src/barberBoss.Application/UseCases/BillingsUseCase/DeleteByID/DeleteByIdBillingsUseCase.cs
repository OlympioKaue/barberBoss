
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;

namespace barberBoss.Application.UseCases.BillingsUseCase.DeleteByID;

public class DeleteByIdBillingsUseCase : IDeleteByIdBillingsUseCase
{
    private readonly IBillingQuery _billingQuery;
    private readonly IBillingCommand _billingCommand;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteByIdBillingsUseCase(IBillingQuery billingQuery, IBillingCommand billingCommand, IUnitOfWork unitOfWork)
    {
        _billingQuery = billingQuery;
        _billingCommand = billingCommand;
        _unitOfWork = unitOfWork;
    }

    public async Task DeleteById(int id, CancellationToken cancellationToken)
    {
        var getById = await _billingQuery.GetBillingById(id);
        if (getById is null)
        {
            throw new NotFoundSystem("Faturamento não encontrado");
        }

        _billingCommand.Delete(getById, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}
