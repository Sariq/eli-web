using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

public class Employee : DatabaseObject
{
    [DataMember]
    public String UserId    { get; set; }

    [DataMember]
    public String Password  { get; set; }

    [DataMember]
    public String FirstName { get; set; }

    [DataMember]
    public String LastName  { get; set; }

    [DataMember]
    public String Email     { get; set; }

    [DataMember]
    public Boolean IsAdmin  { get; set; }

    [DataMember]
    public Boolean IsOnline { get; set; }

    [DataMember]
    public String Error { get; set; }

    public Employee CreateEmployee(string userId, string password, string firstName, string lastName, string email, bool isAdmin, bool isOnline)
    {
        UserId = userId;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IsAdmin = isAdmin;
        IsOnline = isOnline;
        Error = "NO";
        _id = Convert.ToString((ObjectId.GenerateNewId()));

        return this;
    }

    //    var employeeA = new Employee(userId: "Karin", password: "123", firstName: "Karin", lastName: "Ben-Haun",
    //        email: "karin@gmail.com", isAdmin: true, isOnline: true);
    //    var employeeB = new Employee(userId: "Sari", password: "123", firstName: "Sari", lastName: "Qashuw",
    //        email: "sari@gmail.com", isAdmin: true, isOnline: true);
}