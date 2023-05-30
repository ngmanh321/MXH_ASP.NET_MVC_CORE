using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class APIController : ControllerBase
	{
        //Bang LIKE
        MxhContext db = new MxhContext();
        [HttpGet]
        public IEnumerable<Like> GetLike()
        {
            var sanPham = (from p in db.Likes
                           select new Like
                           {
                               Idpost = p.Idpost,
                               TaiKhoan = p.TaiKhoan,
                           }).ToList();
            return sanPham;
        }

        [HttpGet("{tk}")]
        public IEnumerable<Like> GetLikeBy(string tk)
        {
            var sanPham = (from p in db.Likes
                           where p.TaiKhoan == tk
                           select new Like
                           {
                               Idpost = p.Idpost,
                               TaiKhoan = p.TaiKhoan,
                           }).ToList();
            return sanPham;
        }

        // them like vao post
        [HttpPost("")]
        public IActionResult ThemLike([FromBody] Like sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Likes.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }

        // Xoa like theo bai idpost
        [HttpDelete("{id}/{tk}")]
        public async Task<IActionResult> XoaLike(int id, string tk)
        {

            var sanPham = await db.Likes.FindAsync(id, tk);
            if (sanPham == null)
            {
                return NotFound();
            }
            db.Likes.Remove(sanPham);
            await db.SaveChangesAsync();
            return NoContent();
        }

    }
}
