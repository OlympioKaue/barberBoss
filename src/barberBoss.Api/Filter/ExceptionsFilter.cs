using barberBoss.Communication.Response.Exceptions;
using barberBoss.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace barberBoss.Api.Filter;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ExceptionValidator)
        {
            KnownTreatment(context);
        }
        else
        {
            UnknownTreatment(context);
        }
    }

    private void KnownTreatment(ExceptionContext context)
    {
        var exceptionResult = (ExceptionValidator)context.Exception;
        var responseException = new ResponseExceptions(exceptionResult.GetErrorsMessage());

        context.HttpContext.Response.StatusCode = exceptionResult.StatusCodes;
        context.Result = new ObjectResult(responseException);
    }

    private void UnknownTreatment(ExceptionContext context)
    {
        var responseException = new ResponseExceptions("Erro desconhecido");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(responseException);
    }
}
