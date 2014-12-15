using MongoDB.Bson;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

public class Employee : ValObject, IEmployee
{
    [DataMember]
    public String UserId
    {
        get { return UserId; }
        set { UserId = value; }
    }

    [DataMember]
    public String Password
    {
        get { return Password; }
        set { Password = value; }
    }

    [DataMember]
    public String FirstName
    {
        get { return FirstName; }
        set { FirstName = value; }
    }

    [DataMember]
    public String LastName
    {
        get { return LastName; }
        set { LastName = value; }
    }

    [DataMember]
    public String Email
    {
        get { return Email; }
        set { Email = value; }
    }

    [DataMember]
    public Boolean IsAdmin
    {
        get { return IsAdmin; }
        set { IsAdmin = value; }
    }

    [DataMember]
    public Boolean IsOnline
    {
        get { return IsOnline; }
        set { IsOnline = value; }
    }


    public ValObject CreateNewEmployee(string userId, string password, string firstName, string lastName, string email, bool isAdmin, bool isOnline)
    {
        var employee = new Employee();
        employee.UserId = userId;
        employee.Password = password;
        employee.FirstName = firstName;
        employee.LastName = lastName;
        employee.Email = email;
        employee.IsAdmin = isAdmin;
        employee.IsOnline = IsOnline;
        employee._id = Convert.ToString((ObjectId.GenerateNewId()));
        return employee;
    }

    public Employee Initialize()
    {
        var employeeA = CreateNewEmployee(userId: "Karin", password: "123", firstName: "Karin", lastName: "Ben-Haun",
            email: "karin@gmail.com", isAdmin: true, isOnline: true);
        var employeeB = CreateNewEmployee(userId: "Sari", password: "123", firstName: "Sari", lastName: "Qashuw",
            email: "sari@gmail.com", isAdmin: true, isOnline: true);

        AddEmployee(employeeA);
        AddEmployee(employeeB);
        AddEmployee(employeeB);
        AddEmployee(employeeB);

        //RemoveEmployee("548f26bb20e1b61e502a764d");
        
        var employeeList = GetEmployee("Karin");
        return employeeList;
    }

    
    //public Employee SignIn(string id, string userId, string password)
    //{
    //    var employee = GetEmployee(userId);
    //    var isPasswordCorrect = IsPasswordCorrect(employee, password);

    //    if (isPasswordCorrect)
    //        return employee;
    //    return null;
    //}

    public void AddEmployee(ValObject employee)
    {
        InsertObject(employee, "Employee");
    }
    
    private Boolean IsPasswordCorrect(Employee employee, string password)
    {
        return (employee.password == password);
    }

    private Employee GetEmployee(string employeUserId)
    {
        return (Employee)GetObject("UserId", employeUserId, "Employee").Result;
    }

    private void RemoveEmployee(string employeId)
    {
        RemoveObject(employeId, "Employee");
    }

    private void UpdateEmployee(ValObject employee)
    {
        UpdateObject(employee, "Employee");
    }

    private List<Employee> GetAllEmployees()
    {
        var list = GetAllObject("Employee");
        var x = list.Result;
        var employeeList = x.ConvertAll<Employee>(obj => (Employee)obj);
        return employeeList;
    }    
}