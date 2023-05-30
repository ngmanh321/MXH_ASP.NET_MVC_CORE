using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class API6Controller : ControllerBase
	{
		//Bang Chat
		MxhContext db = new MxhContext();

		[HttpGet]
		public IEnumerable<Chat> GetChat()
		{
			var sanPham = (from p in db.Chats
						   select new Chat
						   {
							   Idchat = p.Idchat,
							   Tkgui = p.Tkgui,
							   Tknhan = p.Tknhan,
							   NoiDung = p.NoiDung,
							   NgayTao = p.NgayTao,
							   ViTri = p.ViTri,

						   }).ToList();
			return sanPham;
		}

		[HttpGet("{vt}/{tk}")]
		public IEnumerable<Chat> GetChatBy( int vt ,  string tk )
		{
			var sanPham = (from p in db.Chats
						   where p.ViTri== vt && p.Tknhan == tk 
						   select new Chat
						   {
							   Idchat = p.Idchat,
							   Tkgui = p.Tkgui,
							   Tknhan = p.Tknhan,
							   NoiDung = p.NoiDung,
							   NgayTao = p.NgayTao,
							   ViTri = p.ViTri,

						   }).ToList();
			return sanPham;
		}

		// them Chat 
		[HttpPost("")]
		public IActionResult ThemComment([FromBody] Chat sanPham)
		{
			if (ModelState.IsValid)
			{
				db.Chats.Add(sanPham);
				db.SaveChanges();
			}
			return Ok(sanPham);
		}
	}
}
