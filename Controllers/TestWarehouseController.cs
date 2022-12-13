using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonKhoatnhom4.Data;
using SonKhoatnhom4.Models;
using SonKhoatnhom4.Models.Process;
namespace SonKhoatnhom4.Controllers
{
    public class TestWarehouseController : Controller
    {
 private readonly ApplicationDbContext _context;
       

        public TestWarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryProduct
        public async Task<IActionResult> Index()
        {
              return _context.Warehouse != null ? 
                          View(await _context.Warehouse.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Warehouse'  is null.");
        }
        [HttpPost]
          public IActionResult Create()
    {
    
        return View();
    }
   
    };
}
