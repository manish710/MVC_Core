using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCDemo_10Apr2019.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CompanyName = "JLT";
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}