using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

public class EmployeeService : DatabaseActions, IEmployee
{

    public Employee SignIn(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);

        if (employee._password != dbEmployee._password)
        {
            var error = new Error(Error.ErrorType.PasswordIsIncorrect);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        if (employee._isRememberMe)
        {
            dbEmployee._isRememberMe = true;
            var employeeId = dbEmployee._id;
            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie] = string.Format("TokenId={0}", employeeId);
        }
        else
            dbEmployee._isRememberMe = false;

        return dbEmployee;
    }

    public void SignOut()
    {
        HttpContext.Current.Request.Cookies.Remove("TokenId");
    }

    public void AddEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee == null)
            InsertObject(employee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsAlreadyExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void RemoveEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee != null)
            RemoveObject(dbEmployee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee != null)
            UpdateObject(dbEmployee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public Employee GetEmployee(Employee employee)
    {
        try
        {
            return GetObject<Employee>("_userId", employee._userId, "Employee").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public List<Employee> GetAllEmployees()
    {
        return GetAllObject<Employee>("Employee").Result;
    }

}