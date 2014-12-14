using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    private String _FirstName;
   
    [DataMember(Name = "FirstName")]
    public String FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    
}