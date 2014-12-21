public class ErrorService : DatabaseActions, IError
{
    public void AddError(Error error)
    {
        InsertObject(error, "Error");
    }
}