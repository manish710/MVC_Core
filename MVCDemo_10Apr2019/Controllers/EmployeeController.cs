using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCDemo_10Apr2019.Models;

namespace MVCDemo_10Apr2019.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Employee emp = new Employee { EmpId=1,EmployeeName="Hari",Salary=2000 };
            
            return View(emp);
        }

        public IActionResult List()
        {
            Employee emp = new Employee();
            return View(emp.EmployeeCollection());
        }

        public IActionResult Details(int id)
        {
            Employee emp = new Employee();
            return View("Index", emp.EmployeeCollection().Where(row => row.EmpId == id).SingleOrDefault());
            //return View("Index", emp.EmployeeCollection().Find(row => row.EmpId == id));
        }
    }
}