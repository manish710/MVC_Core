using CRUDoperation_MVCCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperation_MVCCORE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly JLTDataContext dataContext;

        public EmployeeController(JLTDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(dataContext.Employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dataContext.Employee.Add(employee);
                dataContext.SaveChanges();
            }
            return View();
        }
    }
}