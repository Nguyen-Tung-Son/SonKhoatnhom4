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
    public class ImportStorageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportStorageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImportStorage
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ImportStorage.Include(i => i.CategoryProduct).Include(i => i.DanhsachNCC);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ImportStorage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ImportStorage == null)
            {
                return NotFound();
            }

            var importStorage = await _context.ImportStorage
                .Include(i => i.CategoryProduct)
                .Include(i => i.DanhsachNCC)
                .FirstOrDefaultAsync(m => m.MaNhapKho == id);
            if (importStorage == null)
            {
                return NotFound();
            }

            return View(importStorage);
        }

        // GET: ImportStorage/Create
        public IActionResult Create()
        {
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa");
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc");
            return View();
        }

        // POST: ImportStorage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhapKho,MaHangHoa,SoLuong,NgayNhapKho,Mancc")] ImportStorage importStorage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importStorage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", importStorage.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", importStorage.Mancc);
            return View(importStorage);
        }

        // GET: ImportStorage/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ImportStorage == null)
            {
                return NotFound();
            }

            var importStorage = await _context.ImportStorage.FindAsync(id);
            if (importStorage == null)
            {
                return NotFound();
            }
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", importStorage.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", importStorage.Mancc);
            return View(importStorage);
        }

        // POST: ImportStorage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhapKho,MaHangHoa,SoLuong,NgayNhapKho,Mancc")] ImportStorage importStorage)
        {
            if (id != importStorage.MaNhapKho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importStorage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportStorageExists(importStorage.MaNhapKho))
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
            ViewData["MaHangHoa"] = new SelectList(_context.Set<CategoryProduct>(), "MaHangHoa", "MaHangHoa", importStorage.MaHangHoa);
            ViewData["Mancc"] = new SelectList(_context.DanhsachNCC, "Mancc", "Mancc", importStorage.Mancc);
            return View(importStorage);
        }

        // GET: ImportStorage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ImportStorage == null)
            {
                return NotFound();
            }

            var importStorage = await _context.ImportStorage
                .Include(i => i.CategoryProduct)
                .Include(i => i.DanhsachNCC)
                .FirstOrDefaultAsync(m => m.MaNhapKho == id);
            if (importStorage == null)
            {
                return NotFound();
            }

            return View(importStorage);
        }

        // POST: ImportStorage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ImportStorage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ImportStorage'  is null.");
            }
            var importStorage = await _context.ImportStorage.FindAsync(id);
            if (importStorage != null)
            {
                _context.ImportStorage.Remove(importStorage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportStorageExists(string id)
        {
          return (_context.ImportStorage?.Any(e => e.MaNhapKho == id)).GetValueOrDefault();
        }
    }
}
