using System;
using System.Collections.Generic;

namespace MangXaHoi.Models;

public partial class Post
{
    public int Idpost { get; set; }

    public string? TaiKhoan { get; set; }

    public string? Avatar { get; set; }

    public string? NoiDung { get; set; }

    public string? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual Nguoidung? TaiKhoanNavigation { get; set; }
}
