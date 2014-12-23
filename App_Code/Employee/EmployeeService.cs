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
        var getEmployee = GetEmployee(employee);
        return getEmployee;
        //if (getEmployee == null)
        //{
        //    var error = new Error(Error.ErrorType.UserIsNotExist);
        //    throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        //}
        
        //if (employee._password != getEmployee._password)
        //{
        //    var error = new Error(Error.ErrorType.PasswordIsIncorrect);
        //    throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        //}

        //if (employee._isRememberMe)
        //{
        //    getEmployee._isRememberMe = true;
        //    var employeeId = getEmployee._id;
        //    WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie] = string.Format("TokenId={0}", employeeId);
        //}
        //else
        //    getEmployee._isRememberMe = false;

        //return getEmployee;
    }

    public void SignOut()
    {
        HttpContext.Current.Request.Cookies.Remove("TokenId");
    }

    public void AddEmployee(Employee employee)
    {
        var getEmployee = GetEmployee(employee);
        if (getEmployee == null)
            InsertObject(employee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsAlreadyExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void RemoveEmployee(Employee employee)
    {
        var getEmployee = GetEmployee(employee);
        if (getEmployee != null)
            RemoveObject(getEmployee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        var getEmployee = GetEmployee(employee);
        if (getEmployee != null)
            UpdateObject(getEmployee, "Employee");
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