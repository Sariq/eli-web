using System.Runtime.Serialization;

[DataContract]
public class Error : DatabaseObject
{
    public enum ErrorType
    {
        PasswordIsIncorrect,
        UserIsNotExist,
        UserIsAlreadyExist,
        Password
    }

    [DataMember] public string _errorDescription { get; set; }


    public Error(ErrorType errorType) : base()
    {
        _errorDescription = errorType.ToString();
    }

}