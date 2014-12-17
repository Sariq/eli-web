using System;
using System.Collections.Generic;

public class EmployeeService : DatabaseObject, IEmployee
{
    Database database = new Database();

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
            if (employee.Password == getEmployee.Password)
                return getEmployee;
            else
            {
                employee.Error = "Password Is Incorrect";
                return employee;
            }
        }
        employee.Error = "User Is Not Exist";
        return employee;
    }

    public void AddEmployee(Employee employee)
    {
        InsertObject(employee, "Employee");
    }

    public void RemoveEmployee(Employee employee)
    {
        RemoveObject(employee, "Employee");
    }

    public void UpdateEmployee(Employee employee)
    {
        UpdateObject(employee, "Employee");
    }

    public Employee GetEmployee(Employee employee)
    {
        return GetObject<Employee>("UserId", employee.UserId, "Employee").Result;
    }

    public List<Employee> GetAllEmployees()
    {
        return GetAllObject<Employee>("Employee").Result;
    }  

}