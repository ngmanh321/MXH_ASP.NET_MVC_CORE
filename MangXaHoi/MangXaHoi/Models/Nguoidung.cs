using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangXaHoi.Models;

public partial class Nguoidung
{
    [Required(ErrorMessage = "Tên TK không được để trống")]
    [RegularExpression(@"^.{3,}$", ErrorMessage = "TenTK phải có độ dài lớn hơn 2 kí tự")]
    public string TaiKhoan { get; set; } = null!;

    [Required(ErrorMessage = "MK không được để trống")]
    [RegularExpression(@"^.{3,}$", ErrorMessage = "MK phải có độ dài lớn hơn 2 kí tự")]
    public string? MatKhau { get; set; }

    public string? Ten { get; set; }

    public string? Sdt { get; set; }

    public string? GioiTinh { get; set; }

    public string? NgaySinh { get; set; }

    [Required(ErrorMessage = "AnhBia không được để trống")]
    public string? AnhBia { get; set; }

    [Required(ErrorMessage = "Avatar không được để trống")]
    public string? Avatar { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? GioiThieu { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
