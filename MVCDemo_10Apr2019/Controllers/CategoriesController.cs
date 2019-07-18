using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCDemo_10Apr2019.Models;
using MVCDemo_10Apr2019.ViewModel;

namespace MVCDemo_10Apr2019.Controllers
{
    public class CategoriesController : Controller
    {
        NORTHWNDContext ctx = new NORTHWNDContext();

        public IActionResult Index()
        {
            CategoryProduct_ViewModel catProd = new CategoryProduct_ViewModel();
            catProd.Categories = ctx.Categories.ToList();
            catProd.Products = ctx.Products.Where(cat => cat.CategoryId == 1).ToList();
            return View(catProd);
        }

        [HttpPost]
        public IActionResult Index(int Category)
        {
            ViewBag.SelectedItem = Category;
            CategoryProduct_ViewModel catProd = new CategoryProduct_ViewModel();
            catProd.Categories = ctx.Categories.ToList();
            catProd.Products = ctx.Products.Where(cat => cat.CategoryId == Category).ToList();
            return View(catProd);
        }

        public string CategoryCount(int id)
        {
            var prodList = ctx.Categories.Where(row => row.CategoryId == id).Select(row => row.Products).ToList();
            //var prodlst = ctx.Categories.Where(row => row.CategoryId == id).GroupBy(a => a.CategoryId).Select(g=>g.Count());
            //return prodlst.ToString();
            return prodList[0].Count.ToString();
            //return "Succes";
        }

        //public IActionResult ProductListing(int CatId)
        //{
        //    var prodList = ctx.Categories.Where(cat => cat.CategoryId == CatId).Select(row => row.Products);
        //    return View(prodList);
        //}
    }
}