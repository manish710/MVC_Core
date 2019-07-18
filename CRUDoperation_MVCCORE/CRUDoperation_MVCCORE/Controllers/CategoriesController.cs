using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDoperation_MVCCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperation_MVCCORE.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly JLTDataContext dataContext;

        public CategoriesController(JLTDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(dataContext.Categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            dataContext.Categories.Add(category);
            dataContext.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int Id)
        //{
        //    return View();
        //}

        //public IActionResult Details(int Id)
        //{
        //    return View();
        //}
    }
}