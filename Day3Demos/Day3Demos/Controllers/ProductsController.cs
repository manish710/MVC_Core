using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day3Demos.Models;

namespace Day3Demos.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NORTHWNDContext _context;

        public ProductsController(NORTHWNDContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string filterByPname)
        {
            ViewBag.currentFilter = filterByPname;

            ViewData["PId_SortOrder"] = sortOrder == "PId_asc" ? "PId_desc" : "PId_asc";
            ViewData["PName_SortOrder"] = sortOrder == "PName_asc" ? "PName_desc" : "PName_asc";
            ViewData["UPrice_SortOrder"] = sortOrder == "UPrice_asc" ? "UPrice_desc" : "UPrice_asc";

            var nORTHWNDContext = _context.Products.Include(p => p.Category).Select(p=>p);

            if(!string.IsNullOrEmpty(filterByPname))
            {
                nORTHWNDContext = nORTHWNDContext.Where(p => p.ProductName.StartsWith(filterByPname));
            }

            switch (sortOrder)
            {
                case "PId_asc":
                    nORTHWNDContext = nORTHWNDContext.OrderBy(p=>p.ProductId);
                    break;
                case "PId_desc":
                    nORTHWNDContext = nORTHWNDContext.OrderByDescending(p => p.ProductId);
                    break;
                case "PName_asc":
                    nORTHWNDContext = nORTHWNDContext.OrderBy(p => p.ProductName);
                    break;
                case "PName_desc":
                    nORTHWNDContext = nORTHWNDContext.OrderByDescending(p => p.ProductName);
                    break;
                case "UPrice_asc":
                    nORTHWNDContext = nORTHWNDContext.OrderBy(p => p.UnitPrice);
                    break;
                case "UPrice_desc":
                    nORTHWNDContext = nORTHWNDContext.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    break;
            }

            return View(await nORTHWNDContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
