using System;
using System.Collections.Generic;

namespace MangXaHoi.Models;

public partial class Friend
{
    public string Tkgui { get; set; } = null!;

    public int? TrangThai { get; set; }

    public string Tknhan { get; set; } = null!;

    public string? AvatarGui { get; set; }

    public string? AvatarNhan { get; set; }
}
