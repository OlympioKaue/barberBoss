using System.Net;

namespace barberBoss.Exception.ExceptionBase;

public class NotFoundSystem : ExceptionValidator
{
    private readonly List<string> _errors;

    public NotFoundSystem(List<string> errors) : base(string.Empty) {_errors = errors;}
    public NotFoundSystem(string errors) : base(string.Empty) {_errors = [errors];}

    public override int StatusCodes =>(int) HttpStatusCode.NotFound;

    public override List<string> GetErrorsMessage()
    {
        return _errors;
    }
}
