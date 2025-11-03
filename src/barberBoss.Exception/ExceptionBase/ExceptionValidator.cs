namespace barberBoss.Exception.ExceptionBase;

public abstract class ExceptionValidator : SystemException
{
    protected ExceptionValidator(string message) : base(message) { } 

    public abstract int StatusCodes { get; }
    public abstract List<string> GetErrorsMessage();

}
