using System.ComponentModel.DataAnnotations;

namespace SonKhoatnhom4.Models;

public class CategoryProduct {
    [Key]
    public string? MaHangHoa { get; set; }

    public string? TenHangHoa { get; set; }
    public string? Thongtinhanghoa { get; set; }
    
    
}