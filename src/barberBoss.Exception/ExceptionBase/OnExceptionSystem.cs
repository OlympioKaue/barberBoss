using System.Net;

namespace barberBoss.Exception.ExceptionBase;

public class OnExceptionSystem : ExceptionValidator
{
    private readonly List<string> _errors; 
    public OnExceptionSystem(List<string> errors) : base(string.Empty)
    {
        _errors = errors;
    }

    public override int StatusCodes =>(int) HttpStatusCode.BadRequest;

    public override List<string> GetErrorsMessage()
    {
        return _errors;
    }
}
