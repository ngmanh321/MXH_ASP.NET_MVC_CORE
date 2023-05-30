using Azure;
using MangXaHoi.Models;
using MangXaHoi.Models.Authenlication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace MangXaHoi.Controllers
{
    public class HomeController : Controller
    {
        MxhContext db = new MxhContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Authentication]
        public IActionResult Index(string taikhoan, int? page)
        {
            string tk = HttpContext.Session.GetString("DN");
            taikhoan = tk;

            int pageSize = 400;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var lstsanpham = db.Posts.AsNoTracking().Where(x => x.TaiKhoan == taikhoan).OrderByDescending(x => x.Idpost);
            PagedList<Post> lst = new PagedList<Post>(lstsanpham, pageNumber, pageSize);

            ViewBag.taikhoan = taikhoan;

            return View(lst);
        }


        // Them post
        [HttpGet]
        [Route("Post")]

        public IActionResult Post()
        {

            return View(new Post());
        }

        [Route("Post")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(Post sanPham)
        {
            string tk = HttpContext.Session.GetString("DN");
            db.Posts.Add(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // Sua Post

        [HttpGet]
        [Route("SuaPost")]

        public IActionResult SuaPost(int id)
        {
            Post sanPham = db.Posts.Find(id);
            return View(sanPham);
        }


        [Route("SuaPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaPost(Post sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanPham);
        }

        // Xoa Post

        [Route("XoaPost")]
        [HttpGet]
        public IActionResult XoaPost(int id)
        {

            var listLike = db.Likes.Where(x => x.Idpost == id);
            var listComment = db.Comments.Where(x => x.Idpost == id);
            if (listLike.Count() > 0) db.RemoveRange(listLike);
            if (listComment.Count() > 0) db.RemoveRange(listComment);


            db.Remove(db.Posts.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Like( int tk, int? page)
        {

            int pageSize = 400;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var lstsanpham = db.Likes.AsNoTracking().Where(x => x.Idpost == tk).OrderByDescending(x => x.TaiKhoan);
            PagedList<Like> lst = new PagedList<Like>(lstsanpham, pageNumber, pageSize);

            ViewBag.tk = tk;

            return View(lst);
        }


        public IActionResult TrangCaNhan(string taikhoan)
        {
            var sanpham = db.Nguoidungs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
            ViewBag.taikhoan = taikhoan;
            return View(sanpham);
        }

        public IActionResult DongThoiGian(string taikhoan , int? page)
        {
            string tk = HttpContext.Session.GetString("DN");
            //taikhoan = tk;
            HttpContext.Session.SetString("tkfrofile", taikhoan);

            int pageSize = 400;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            if(taikhoan == tk)
            {
                var lstsanpham = db.Posts.AsNoTracking().Where(x => x.TaiKhoan == taikhoan).OrderByDescending(x => x.Idpost);
                PagedList<Post> lst = new PagedList<Post>(lstsanpham, pageNumber, pageSize);
                ViewBag.taikhoan = taikhoan;
                return View(lst);
            }
            else
            {
                var lstsanpham = db.Posts.AsNoTracking().Where(x => x.TaiKhoan == taikhoan && x.TrangThai == "Public").OrderByDescending(x => x.Idpost);
                PagedList<Post> lst = new PagedList<Post>(lstsanpham, pageNumber, pageSize);
                ViewBag.taikhoan = taikhoan;
                return View(lst);
            }


        }


        // Sua Trang Ca Nhan

        [HttpGet]
        [Route("SuaTrangCaNhan")]

        public IActionResult SuaTrangCaNhan(string taikhoan)
        {
            string tk = HttpContext.Session.GetString("DN");
            taikhoan = tk;
            Nguoidung sanPham = db.Nguoidungs.Find(taikhoan);
            return View(sanPham);
        }


        [Route("SuaTrangCaNhan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaTrangCaNhan(Nguoidung sanPham)
        {
            string tk = HttpContext.Session.GetString("DN");

            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Logout", "Access");

            }

            return View(sanPham);
        }

        public IActionResult Friend(string taikhoan)
        {
            var sanpham = db.Nguoidungs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
            ViewBag.taikhoan = taikhoan;
            return View(sanpham);
        }

		public IActionResult Chat(string tkgui , string tknhan , int? page )
		{
			HttpContext.Session.SetString("tk", tknhan);


			int pageSize = 400;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;

			var lstsanpham = db.Chats.AsNoTracking().Where(x => x.Tkgui == tkgui && x.Tknhan == tknhan).OrderBy(x => x.Idchat);
			var lstsanpham1 = db.Chats.AsNoTracking().Where(x => x.Tknhan == tkgui && x.Tkgui == tknhan).OrderBy(x => x.Idchat);

			PagedList<Chat> lst = new PagedList<Chat>(lstsanpham, pageNumber, pageSize);

			return View(lst);
		}


		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}