using System;
using System.Collections.Generic;

namespace MangXaHoi.Models;

public partial class Like
{
    public int Idpost { get; set; }

    public string TaiKhoan { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? NgayTao { get; set; }


}
