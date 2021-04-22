using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LumberManagerWebEdition.Data;
using LumberManagerWebEdition.Models;

namespace LumberManagerWebEdition.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            Category category1 = new Category() { CategoryID = 1, CategoryName = "WW" };
            Category category2 = new Category() { CategoryID = 2, CategoryName = ".25" };
            Category category3 = new Category() { CategoryID = 3, CategoryName = ".40" };
            Category category4 = new Category() { CategoryID = 4, CategoryName = ".60" };
            Category category5 = new Category() { CategoryID = 5, CategoryName = "ACQ" };
            Category category6 = new Category() { CategoryID = 6, CategoryName = "CCA" };
            createProductViewModel.Categories.Add(category1);
            createProductViewModel.Categories.Add(category2);
            createProductViewModel.Categories.Add(category3);
            createProductViewModel.Categories.Add(category4);
            createProductViewModel.Categories.Add(category5);
            createProductViewModel.Categories.Add(category6);
            return View(createProductViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
            {
                bool wwSelected = (Request.Form["ww"] == "WW") ? true : false;
                bool twoFiveSelected = (Request.Form[".25"] == ".25") ? true : false;
                bool four0Selected = (Request.Form[".40"] == ".40") ? true : false;
                bool six0Selected = (Request.Form[".60"] == ".60") ? true : false;
                bool acqSelected = (Request.Form["acq"] == "ACQ") ? true : false;
                bool ccaSelected = (Request.Form["cca"] == "CCA") ? true : false;
                if (wwSelected)
                {
                    createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 1));
                }
                else
                {
                    if (twoFiveSelected && acqSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 2));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 5));
                    }
                    else if (twoFiveSelected && ccaSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 2));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 6));
                    }
                    else if (four0Selected && acqSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 3));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 5));
                    }
                    else if (four0Selected && ccaSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 3));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 6));
                    }
                    else if (six0Selected && acqSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 4));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 5));
                    }
                    else if (six0Selected && ccaSelected)
                    {
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 4));
                        createProductViewModel.Product.Category.Add(CategoryDb.GetCategory(_context, 6));
                    }
                }
                await ProductDb.AddProductAsync(_context, createProductViewModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createProductViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> UpdateInventory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInventory(int id, [Bind("ProductID,Height,Width,Length,OnHand,Sold")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
