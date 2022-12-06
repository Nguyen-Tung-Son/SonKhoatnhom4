using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SonKhoatnhom4.Models;

namespace SonKhoatnhom4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SonKhoatnhom4.Models.Danhsachkhachhang> Danhsachkhachhang { get; set; } = default!;

        public DbSet<SonKhoatnhom4.Models.Danhsachnhanvien> Danhsachnhanvien { get; set; } = default!;

        public DbSet<SonKhoatnhom4.Models.DanhsachNCC> DanhsachNCC { get; set; } = default!;

        public DbSet<SonKhoatnhom4.Models.ImportStorage> ImportStorage { get; set; } = default!;

        public DbSet<SonKhoatnhom4.Models.Warehouse> Warehouse { get; set; } = default!;

        public DbSet<SonKhoatnhom4.Models.CategoryProduct> CategoryProduct { get; set; } = default!;

    
    }
}
