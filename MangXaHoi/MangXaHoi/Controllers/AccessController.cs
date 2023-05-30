using MangXaHoi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoi.Controllers
{
    public class AccessController : Controller
    {

        MxhContext db = new MxhContext();
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("DN") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(Nguoidung user)
        {
            if (HttpContext.Session.GetString("DN") == null)
            {
                var u = db.Nguoidungs.Where(x => x.TaiKhoan == user.TaiKhoan && x.MatKhau == user.MatKhau).FirstOrDefault();


                if (u != null)
                {

                    HttpContext.Session.SetString("DN", u.TaiKhoan.ToString());
                    HttpContext.Session.SetString("Avatar", u.Avatar.ToString());
                    return RedirectToAction("Index", "Home");

                }


            }
            return View(user);
        }


        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("DN");
            return RedirectToAction("Login", "Access");
        }
    }
}
