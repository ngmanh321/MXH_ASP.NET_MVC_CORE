using System;
using System.Collections.Generic;

namespace MangXaHoi.Models;

public partial class Chat
{
    public int Idchat { get; set; }

    public string? Tkgui { get; set; }

    public string? Tknhan { get; set; }

    public string? AvatarGui { get; set; }

    public string? AvatarNhan { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NoiDung { get; set; }
	public int ViTri { get; set; }

}
