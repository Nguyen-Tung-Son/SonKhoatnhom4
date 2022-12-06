using System.ComponentModel.DataAnnotations;

namespace SonKhoatnhom4.Models;

public class Danhsachnhanvien
{
    [Key]
    [Required(ErrorMessage = "Mã  nhân viên không được để trống !!!")]
    public string? Manhanvien { get; set; }
    [Required(ErrorMessage = "Tên nhân viên không được để trống !!!")]
    public string? Tennhanvien{ get; set; }
  
    public string? Diachi { get; set; }
    public int Sodienthoai { get; set; }
     
}