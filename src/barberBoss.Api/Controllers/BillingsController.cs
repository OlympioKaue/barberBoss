using barberBoss.Application.UseCases.BillingsUseCase.DeleteByID;
using barberBoss.Application.UseCases.BillingsUseCase.Get;
using barberBoss.Application.UseCases.BillingsUseCase.GetByID;
using barberBoss.Application.UseCases.BillingsUseCase.Register;
using barberBoss.Application.UseCases.BillingsUseCase.Update;
using barberBoss.Communication.Request.Billings;
using barberBoss.Communication.Response.Billings;
using Microsoft.AspNetCore.Mvc;

namespace barberBoss.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register
        (CancellationToken cancellationToken,
        [FromServices] IRegisterBillingsUseCase useCase,
        [FromBody] RequestBillings request)
    {
        var resultUseCase = await useCase.RegisterExecute(cancellationToken, request);
        return Created("", resultUseCase);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseBillings), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IGetBillingsUseCase useCase, [FromQuery] int numberPage, [FromQuery] int numberSize)
    {
        var result = await useCase.GetBillings(numberPage, numberSize);
        return Ok(result);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] IGetByIdBillingUseCase useCase)
    {
        var result = await useCase.GetByIdBilling(id);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById([FromRoute] int id, 
        [FromServices] IUpdateByIdBillingUseCase useCase, 
        [FromBody] RequestBillings request, 
        CancellationToken cancellationToken)
    {
        await useCase.UpdateById(id, request, cancellationToken);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteById([FromRoute] int id,[FromServices] IDeleteByIdBillingsUseCase useCase, CancellationToken cancellationToken)
    {
        await useCase.DeleteById(id, cancellationToken);
        return NoContent();
    }
}
