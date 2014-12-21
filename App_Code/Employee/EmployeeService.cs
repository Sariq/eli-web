using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

public class EmployeeService : DatabaseActions, IEmployee
{
    //public List<Employee> EmployeeList(Employee employee)
    //{
    //    var getEmployee = GetAllEmployees();
    //    return getEmployee;
    //}

    public Employee SignIn(Employee employee)
    {
        var getEmployee = GetEmployee(employee);

        if (getEmployee != null)
        {
            if (employee._password == getEmployee._password)
                return getEmployee;
            else
            {
                var error = new Error(Error.ErrorType.PasswordIsIncorrect);
                throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
            }
        }
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
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
            return GetObject<Employee>("UserId", employee._userId, "Employee").Result;
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