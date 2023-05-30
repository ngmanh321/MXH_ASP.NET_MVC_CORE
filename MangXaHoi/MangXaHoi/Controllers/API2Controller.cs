using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class API2Controller : ControllerBase
	{
        //Bang COMMENT
        MxhContext db = new MxhContext();

        [HttpGet]
        public IEnumerable<Comment> GetComment()
        {
            var sanPham = (from p in db.Comments
                           select new Comment
                           {
                               Idcomment = p.Idcomment,
                               TaiKhoan = p.TaiKhoan,
                               Idpost = p.Idpost,
                               NoiDung = p.NoiDung,
                               NgayTao = p.NgayTao,
                               Avatar = p.Avatar,

                           }).ToList();
            return sanPham;
        }

        [HttpGet("{id}")]
        public IEnumerable<Comment> GetCommentBy(int id)
        {
            var sanPham = (from p in db.Comments
                           where p.Idpost == id
                           select new Comment
                           {
                               Idcomment = p.Idcomment,
                               TaiKhoan = p.TaiKhoan,
                               Idpost = p.Idpost,
                               NoiDung = p.NoiDung,
                               NgayTao = p.NgayTao,
                               Avatar = p.Avatar,

                           }).ToList();
            return sanPham;
        }

        // them vao trang thai cua don hang
        [HttpPost("")]
        public IActionResult ThemComment([FromBody] Comment sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }
    }
}
