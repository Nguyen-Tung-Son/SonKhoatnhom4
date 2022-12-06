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
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Warehouse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Warehouse.Include(w => w.CategoryProduct).Include(w => w.DanhsachNCC);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Warehouse/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse
                .Include(w => w.CategoryProduct)
                .Include(w => w.DanhsachNCC)
                .FirstOrDefaultAsync(m => m.MaHangHoa == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // GET: Warehouse/Create
        public IActionResult Create()
        {
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa");
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc");
            ViewData["Tenncc"] = new SelectList(_context.DanhsachNCC, "Tenncc", "Tenncc");
            return View();
        }

        // POST: Warehouse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHangHoa,TenHangHoa,Mancc,Tenncc,Trangthai")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", warehouse.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", warehouse.Mancc);
            ViewData["Tenncc"] = new SelectList(_context.DanhsachNCC, "Tenncc", "Tenncc", warehouse.Tenncc);

            return View(warehouse);
        }

        // GET: Warehouse/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", warehouse.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", warehouse.Mancc);
            return View(warehouse);
        }

        // POST: Warehouse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHangHoa,TenHangHoa,Mancc,Tenncc,Trangthai")] Warehouse warehouse)
        {
            if (id != warehouse.MaHangHoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.MaHangHoa))
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
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", warehouse.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", warehouse.Mancc);
            return View(warehouse);
        }

        // GET: Warehouse/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Warehouse == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouse
                .Include(w => w.CategoryProduct)
                .Include(w => w.DanhsachNCC)
                .FirstOrDefaultAsync(m => m.MaHangHoa == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Warehouse == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Warehouse'  is null.");
            }
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouse.Remove(warehouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseExists(string id)
        {
          return (_context.Warehouse?.Any(e => e.MaHangHoa == id)).GetValueOrDefault();
        }
    }
}
