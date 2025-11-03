namespace barberBoss.Communication.Response.Exceptions;

public class ResponseExceptions
{
    public List<string> Errors { get; set; } = [];
    public ResponseExceptions(List<string> erros)
    {
        Errors = erros;
    }

    public ResponseExceptions(string erros)
    {
        Errors = [erros];
    }
}
