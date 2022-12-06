using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonKhoatnhom4.Data;
using SonKhoatnhom4.Models;

namespace SonKhoatnhom4.Controllers
{
    public class CategoryProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryProduct
        public async Task<IActionResult> Index()
        {
              return _context.CategoryProduct != null ? 
                          View(await _context.CategoryProduct.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CategoryProduct'  is null.");
        }

        // GET: CategoryProduct/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CategoryProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoryProduct
                .FirstOrDefaultAsync(m => m.MaHangHoa == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // GET: CategoryProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHangHoa,TenHangHoa,Thongtinhanghoa")] CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryProduct);
        }

        // GET: CategoryProduct/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CategoryProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoryProduct.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }
            return View(categoryProduct);
        }

        // POST: CategoryProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHangHoa,TenHangHoa,Thongtinhanghoa")] CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.MaHangHoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryProductExists(categoryProduct.MaHangHoa))
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
            return View(categoryProduct);
        }

        // GET: CategoryProduct/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CategoryProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoryProduct
                .FirstOrDefaultAsync(m => m.MaHangHoa == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        // POST: CategoryProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CategoryProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CategoryProduct'  is null.");
            }
            var categoryProduct = await _context.CategoryProduct.FindAsync(id);
            if (categoryProduct != null)
            {
                _context.CategoryProduct.Remove(categoryProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryProductExists(string id)
        {
          return (_context.CategoryProduct?.Any(e => e.MaHangHoa == id)).GetValueOrDefault();
        }
    }
}
