using MangXaHoi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API5Controller : ControllerBase
    {
        //Bang Nguoidung
        MxhContext db = new MxhContext();

        // them Nguoidung
        [HttpPost("")]
        public IActionResult ThemLike([FromBody] Nguoidung sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Nguoidungs.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }
    }
}
