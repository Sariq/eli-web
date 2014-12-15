using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

public class UserService : ValObject
{
    public String _firstName;
    public String _lastName;
    public String _userId;
    public String _password;

    [DataMember(Name = "FirstName")]
    public String FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    [DataMember(Name = "LastName")]
    public String LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    [DataMember(Name = "UserId")]
    public String UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    [DataMember(Name = "Password")]
    public String Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public ValObject GetObject(string userId)
    {
        return GetObject("_id", userId, "User").Result;
    }

    public void InsertObject(ValObject obj)
    {
        InsertObject(obj, "User");
    }

    public void RemoveObject(string userId)
    {
        RemoveObject(userId, "User");
    }

    public void UpdateObject(ValObject obj)
    {
        UpdateObject(obj, "User");
    }

    //public List<ValObject> GetAllObject()
    //{
    //    return GetAllObject("User").Result;
    //}

    //public UserService MyFunction(string str)
    //{
    //    UserService val3 = new UserService();
    //    val3.FirstName = "Karin";
    //    val3.LastName = "B";
    //    val3.UserId = "kkk";
    //    val3.Password = "kkk";
    //    val3._id = Convert.ToString((ObjectId.GenerateNewId()));

    //    UserService val2 = new UserService();
    //    val2.FirstName = "Sari";
    //    val2.LastName = "Q";
    //    val2.UserId = "sss";
    //    val2.Password = "sss";
    //    val2._id = Convert.ToString((ObjectId.GenerateNewId()));

    //    var collection = new Service().CreateCollection("User");
    //    InsertObject(val2);
    //    InsertObject(val3);

    //    //RemoveObject("548b038120e1de04a0192091");
    //    //UpdateInCollection(val2, "A");
    //    //try
    //    //{
    //    //    var obj = GetObjById("1", "B");

    //    //    Debug.WriteLine(obj);
    //    //    return obj;
    //    //}
    //    //catch
    //    //{
    //    //    Debug.WriteLine("str");
    //    //    return null;
    //    //}

    //    var obj = (UserService)GetObject("1");
        
    //    //obj.Result = (List<UserService>)obj.Result;
    //    return obj;
    //}

    public List<UserService> ConvertToUserServiceServiceList(List<ValObject> list)
    {
        return list.ConvertAll<UserService>(a => (UserService)a);
    }
}