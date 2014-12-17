using System;
using System.Runtime.Serialization;

public class Error : DatabaseObject
{
    [DataMember] 
    public String Description   { get; set; }

	public Error Error_PasswordIsIncorrect()
	{
        Description = "Password Is Inccorect";
        return this;
	}

    public Error Error_UserIsNotExist()
    {
        Description = "User Is Not Exist";
        return this;
    }
}