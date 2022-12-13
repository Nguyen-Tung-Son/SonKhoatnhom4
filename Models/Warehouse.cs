using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SonKhoatnhom4.Models;

public class Warehouse {
    [Key]
    public string? MaHangHoa { get; set; }
    [ForeignKey("MaHangHoa")]
     public CategoryProduct? CategoryProduct {get; set;}

    public string? TenHangHoa { get; set; }
    public string? Mancc { get; set; }
     [ForeignKey("Mancc")]
     public DanhsachNCC? DanhsachNCC {get; set;}
    
    public string? Tenncc { get; set; }
    public string? Trangthai { get; set; }
    public string? MaXuatkho { get; set; }
     public string? Makhachhang { get; set; }
     [ForeignKey("Makhachhang")]
     public Danhsachkhachhang? Danhsachkhachhang {get; set;}
    
    
}