using System;
using System.Collections.Generic;

namespace MangXaHoi.Models;

public partial class Comment
{
    public int Idcomment { get; set; }

    public string? TaiKhoan { get; set; }

    public string? Avatar { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public int? Idpost { get; set; }
}
