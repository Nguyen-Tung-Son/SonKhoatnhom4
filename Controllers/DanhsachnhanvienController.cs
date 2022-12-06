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
    public class DanhsachnhanvienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhsachnhanvienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Danhsachnhanvien
        public async Task<IActionResult> Index()
        {
              return _context.Danhsachnhanvien != null ? 
                          View(await _context.Danhsachnhanvien.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Danhsachnhanvien'  is null.");
        }

        // GET: Danhsachnhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Danhsachnhanvien == null)
            {
                return NotFound();
            }

            var danhsachnhanvien = await _context.Danhsachnhanvien
                .FirstOrDefaultAsync(m => m.Manhanvien == id);
            if (danhsachnhanvien == null)
            {
                return NotFound();
            }

            return View(danhsachnhanvien);
        }

        // GET: Danhsachnhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Danhsachnhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manhanvien,Tennhanvien,Diachi,Sodienthoai")] Danhsachnhanvien danhsachnhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhsachnhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhsachnhanvien);
        }

        // GET: Danhsachnhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Danhsachnhanvien == null)
            {
                return NotFound();
            }

            var danhsachnhanvien = await _context.Danhsachnhanvien.FindAsync(id);
            if (danhsachnhanvien == null)
            {
                return NotFound();
            }
            return View(danhsachnhanvien);
        }

        // POST: Danhsachnhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Manhanvien,Tennhanvien,Diachi,Sodienthoai")] Danhsachnhanvien danhsachnhanvien)
        {
            if (id != danhsachnhanvien.Manhanvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhsachnhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhsachnhanvienExists(danhsachnhanvien.Manhanvien))
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
            return View(danhsachnhanvien);
        }

        // GET: Danhsachnhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Danhsachnhanvien == null)
            {
                return NotFound();
            }

            var danhsachnhanvien = await _context.Danhsachnhanvien
                .FirstOrDefaultAsync(m => m.Manhanvien == id);
            if (danhsachnhanvien == null)
            {
                return NotFound();
            }

            return View(danhsachnhanvien);
        }

        // POST: Danhsachnhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Danhsachnhanvien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Danhsachnhanvien'  is null.");
            }
            var danhsachnhanvien = await _context.Danhsachnhanvien.FindAsync(id);
            if (danhsachnhanvien != null)
            {
                _context.Danhsachnhanvien.Remove(danhsachnhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhsachnhanvienExists(string id)
        {
          return (_context.Danhsachnhanvien?.Any(e => e.Manhanvien == id)).GetValueOrDefault();
        }
    }
}
