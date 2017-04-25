using DemoMVC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class EmployeeBusinessLayer
    {
        //public List<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();
        //    Employee emp = new Employee();
        //    emp.FirstName = "johnson";
        //    emp.LastName = " fernandes";
        //    emp.Salary = 14000;
        //    employees.Add(emp);

        //    Employee emp1 = new Employee();
        //    emp1.FirstName = "Enrik";
        //    emp1.LastName = " Iglesias";
        //    emp1.Salary = 18000;
        //    employees.Add(emp1);

        //    Employee emp3 = new Employee();
        //    emp3.FirstName = "Mahbub";
        //    emp3.LastName = " Alam";
        //    emp3.Salary = 13000;
        //    employees.Add(emp3);
        //    return employees;
        //}

        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
//IsValidUser() function is disable for the GetUserValidity().

        //public bool IsValidUser(UserDetails u)
        //{
        //    if (u.UserName == "Admin" && u.Password == "Admin")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Monir" && u.Password == "Monir")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}