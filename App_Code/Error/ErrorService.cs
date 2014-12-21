public class ErrorService : DatabaseActions, IError
{
    public void AddError(Error error)
    {
        Error e = new Error(Error.ErrorType.Password);
        InsertObject(e, "Error");
    }
}