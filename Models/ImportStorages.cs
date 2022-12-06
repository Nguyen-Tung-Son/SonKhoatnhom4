using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SonKhoatnhom4.Models;

public class ImportStorage {
    [Key]
    public string? MaNhapKho { get; set; }

    public string? MaHangHoa { get; set; }
     [ForeignKey("MaHangHoa")]
     public CategoryProduct? CategoryProduct {get; set;}
    public string? SoLuong { get; set; }
    public DateTime NgayNhapKho { get; set; }
    public string? Mancc { get; set; }
     [ForeignKey("Mancc")]
     public DanhsachNCC? DanhsachNCC {get; set;}
    
}