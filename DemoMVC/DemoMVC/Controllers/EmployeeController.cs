using DemoMVC.Models;
using DemoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return this.CustomerName + " | " + this.Address;
        }
    }
    public class EmployeeController : Controller
    {
        // GET: Test
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public string GetString()
        //{
        //    return "Hello world is old now,Its time to say waasup bro.....";
        //}
                
        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            return c;
        }
        [Authorize]
        public ActionResult Index()
        {
            //Employee emp = new Employee();
            //emp.FirstName = "Monir";
            //emp.LastName = "Hossain";
            //emp.Salary = 20000;
            //ViewData["Employee"] = emp;
            //return View("MyView");
            //ViewBag.Employee=emp;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //if (emp.Salary > 15000)
            //{
            //    vmEmp.SalaryColor = "gray";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "red";
            //}

            //vmEmp.Salary = emp.Salary.ToString("C");
            //vmEmp.UserName = "Admin";

            List<Employee> employees = new List<Employee>();
            EmployeeBusinessLayer empBll = new EmployeeBusinessLayer();
            employees = empBll.GetEmployees();
            List<EmployeeViewModel> vmEmployees = new List<EmployeeViewModel>();
            
            foreach(Employee item in employees)
            {
                EmployeeViewModel vmEmp = new EmployeeViewModel();
                vmEmp.EmployeeName = item.FirstName + " " + item.LastName;
                vmEmp.Salary = item.Salary.ToString("C");
                if(item.Salary>15000)
                {
                    vmEmp.SalaryColor = "pink";

                }
                else
                {
                    vmEmp.SalaryColor = "gray";
                }
                vmEmployees.Add(vmEmp); 
            }

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.Employees = vmEmployees;
            employeeListViewModel.UserName = User.Identity.Name; //New Lin;

            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "StepByStepMVC";//Can be set to dynamic value
            employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();

            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }


        //public string SaveEmployee(Employee e)
        //{
        //    return e.FirstName + "|" + e.LastName + "|" + e.Salary;
        //}



        //public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        //{
        //    switch (BtnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index");
        //    }
        //    return new EmptyResult();
        //}

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {

                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary>0)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}