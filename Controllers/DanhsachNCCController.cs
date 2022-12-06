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
    public class DanhsachNCCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhsachNCCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhsachNCC
        public async Task<IActionResult> Index()
        {
              return _context.DanhsachNCC != null ? 
                          View(await _context.DanhsachNCC.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DanhsachNCC'  is null.");
        }

        // GET: DanhsachNCC/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhsachNCC == null)
            {
                return NotFound();
            }

            var danhsachNCC = await _context.DanhsachNCC
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (danhsachNCC == null)
            {
                return NotFound();
            }

            return View(danhsachNCC);
        }

        // GET: DanhsachNCC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhsachNCC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mancc,Tenncc,Sodienthoai,Diachi,Email")] DanhsachNCC danhsachNCC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhsachNCC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhsachNCC);
        }

        // GET: DanhsachNCC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhsachNCC == null)
            {
                return NotFound();
            }

            var danhsachNCC = await _context.DanhsachNCC.FindAsync(id);
            if (danhsachNCC == null)
            {
                return NotFound();
            }
            return View(danhsachNCC);
        }

        // POST: DanhsachNCC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mancc,Tenncc,Sodienthoai,Diachi,Email")] DanhsachNCC danhsachNCC)
        {
            if (id != danhsachNCC.Mancc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhsachNCC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhsachNCCExists(danhsachNCC.Mancc))
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
            return View(danhsachNCC);
        }

        // GET: DanhsachNCC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhsachNCC == null)
            {
                return NotFound();
            }

            var danhsachNCC = await _context.DanhsachNCC
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (danhsachNCC == null)
            {
                return NotFound();
            }

            return View(danhsachNCC);
        }

        // POST: DanhsachNCC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhsachNCC == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhsachNCC'  is null.");
            }
            var danhsachNCC = await _context.DanhsachNCC.FindAsync(id);
            if (danhsachNCC != null)
            {
                _context.DanhsachNCC.Remove(danhsachNCC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhsachNCCExists(string id)
        {
          return (_context.DanhsachNCC?.Any(e => e.Mancc == id)).GetValueOrDefault();
        }
    }
}
