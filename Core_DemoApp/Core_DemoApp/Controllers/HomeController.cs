using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderProcessingService orderProcessingService;
        private readonly IBillingService billingService;
        List<int> orderedProduts;

        public HomeController(IProductService productService, IOrderProcessingService orderProcessingService, IBillingService billingService)
        {
            this.productService = productService;
            this.orderProcessingService = orderProcessingService;
            this.billingService = billingService;
            orderedProduts = new List<int>();
        }

        public IActionResult Index()
        {
            ViewBag.Bill =0;
            return View(productService.Products.Values);
        }

        [HttpPost]
        public IActionResult Index(int prodId)
        {
            //if (this.Session["OrderedProducts"] != null)
            //{
            //    orderedProduts = this.Session["OrderedProducts"] as List<int>;
            //}
            ViewBag.Bill = 0;
            if (TempData["OrderedProducts"] != null)
            {
                orderedProduts = TempData["OrderedProducts"] as List<int>;
            }

            orderedProduts.Add(prodId);

            TempData["OrderedProducts"] = orderedProduts;

            //HttpContext.Session["OrderedProducts"] = orderedProduts;
            //ViewBag.OrderedProducts = orderedProduts;
            TempData.Keep("OrderedProducts");
            return View("Index", productService.Products.Values);
        }

        [HttpPost]
        public IActionResult getBill()
        {
            if (TempData["OrderedProducts"] != null)
            {
                orderProcessingService.PlaceOrder(orderedProduts);
                ViewBag.Bill = billingService.TotalAmount;
            }
            return View("Index", productService.Products.Values);
        }
    }
}