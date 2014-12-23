public class ErrorService : DatabaseActions, IError
{
    public void AddError(Error.ErrorType error)
    {
        Error e = new Error(error);
        InsertObject(e, "Error");
    }
}