using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonKhoatnhom4.Models;

public class DanhsachNCC
{
    [Key]
    [Required(ErrorMessage = "Mã NCC không được để trống !!!")]
    public string? Mancc { get; set; }
    [Required(ErrorMessage = "Tên NCC không được để trống !!!")]
    public string? Tenncc { get; set; }
    
    public int Sodienthoai { get; set; }
    public string? Diachi { get; set; }
    
    public string? Email { get; set; }
     
}