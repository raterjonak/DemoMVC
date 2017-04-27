using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class EmployeeListViewModel:BaseViewModel
    {
       public List<EmployeeViewModel> Employees { get; set; }
      
    //Replace UserName and FooterViewModer properties by layOut page        
        //public string UserName { get; set; }
        //public FooterViewModel FooterData { get; set; }
    }
}