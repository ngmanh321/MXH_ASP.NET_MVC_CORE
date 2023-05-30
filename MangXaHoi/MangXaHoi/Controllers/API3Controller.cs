using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangXaHoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API3Controller : ControllerBase
    {
        //Bang FRIEND
        MxhContext db = new MxhContext();

        [HttpGet]
        public IEnumerable<Friend> GetFriend()
        {
            var sanPham = (from p in db.Friends
                           select new Friend
                           {
                               Tkgui = p.Tkgui,
                               Tknhan = p.Tknhan,
                               TrangThai = p.TrangThai,
                               AvatarGui = p.AvatarGui,
                               AvatarNhan = p.AvatarNhan,
                           }).ToList();
            return sanPham;
        }

        [HttpGet("{tkgui}")]
        public IEnumerable<Friend> GetFriendByTkgui(string tkgui)
        {
            var sanPham = (from p in db.Friends
                           where p.Tkgui == tkgui
                           select new Friend
                           {
                               Tkgui = p.Tkgui,
                               Tknhan = p.Tknhan,
                               TrangThai = p.TrangThai,
                               AvatarGui = p.AvatarGui,
                               AvatarNhan = p.AvatarNhan,

                           }).ToList();
            return sanPham;
        }

        [HttpGet("{0}/{tknhan}")]
        public IEnumerable<Friend> GetFriendtByTknhan(string tknhan)
        {
            var sanPham = (from p in db.Friends
                           where p.Tknhan == tknhan
                           select new Friend
                           {
                               Tkgui = p.Tkgui,
                               Tknhan = p.Tknhan,
                               TrangThai = p.TrangThai,
                               AvatarGui = p.AvatarGui,
                               AvatarNhan = p.AvatarNhan,

                           }).ToList();
            return sanPham;
        }
        // them vao trang thai cua don hang
        [HttpPost("")]
        public IActionResult ThemFriend([FromBody] Friend sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }

        // Sua Friend
        [HttpPut("{tkgui}/{tknhan}")]
        public IActionResult SuaFriend(string tkgui, string tknhan , Friend table)
        {
            if (tkgui != table.Tkgui && tknhan != table.Tknhan)
            {
                return BadRequest();
            }
            db.Entry(table).State = EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // Xoa ADDfriend
        [HttpDelete("{tkgui}/{tknhan}")]
        public async Task<IActionResult> XoaLike(string tkgui, string tknhan)
        {

            var sanPham = await db.Friends.FindAsync(tkgui, tknhan);
            if (sanPham == null)
            {
                return NotFound();
            }
            db.Friends.Remove(sanPham);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
