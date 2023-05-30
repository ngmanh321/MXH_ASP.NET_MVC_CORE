using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class API4Controller : ControllerBase
	{
        //Bang POST
        MxhContext db = new MxhContext();

        [HttpGet]
        public IEnumerable<Post> GetPost()
        {
            var sanPham = (from p in db.Posts
                           select new Post
                           {
                               TaiKhoan = p.TaiKhoan,
                               Idpost = p.Idpost,
                               NoiDung = p.NoiDung,
                               NgayTao = p.NgayTao,
                               Avatar = p.Avatar,
                               TrangThai = p.TrangThai,
                               Anh =  p.Anh,

                           }).ToList();
            return sanPham;
        }

        // Lay ra Post theo TK
        [HttpGet("{tk}")]
        public IEnumerable<Post> GetPosttBy(string tk)
        {
            var sanPham = (from p in db.Posts
                           where p.TaiKhoan == tk
                           orderby p.Idpost descending
                           select new Post
                           {
                               TaiKhoan = p.TaiKhoan,
                               Idpost = p.Idpost,
                               NoiDung = p.NoiDung,
                               NgayTao = p.NgayTao,
                               Avatar = p.Avatar,
                               TrangThai = p.TrangThai,
                               Anh = p.Anh,

                           }).ToList();
            return sanPham;
        }

        // Lay ra Post theo Idpost
        [HttpGet("{0}/{id}")]
        public IEnumerable<Post> GetPosttBy(int id)
        {
            var sanPham = (from p in db.Posts
                           where p.Idpost == id
                           orderby p.Idpost descending

                           select new Post
                           {
                               TaiKhoan = p.TaiKhoan,
                               Idpost = p.Idpost,
                               NoiDung = p.NoiDung,
                               NgayTao = p.NgayTao,
                               Avatar = p.Avatar,
                               TrangThai = p.TrangThai,
                               Anh = p.Anh,

                           }).ToList();
            return sanPham;
        }

        // share post
        [HttpPost("")]
        public IActionResult ThemLike([FromBody] Post sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }
    }
}
