using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SHA_Shop.Controllers
{
    public class UserController : Controller
    {
        SHAshopDB db = new SHAshopDB();

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TaiKhoan, string MatKhau)
        {
            NGUOIDUNG user = db.NGUOIDUNGs.Where(x => x.TaiKhoan == TaiKhoan && x.MatKhau == MatKhau).FirstOrDefault();
            if (user != null)
            {
                Session["TaiKhoan"] = user.TaiKhoan;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session["TaiKhoan"] = "";
            return RedirectToAction("Login", "User");
        }
        //Đăng ký
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NGUOIDUNG user)
        {
            if (ModelState.IsValid)
            {
                var checkAccout = db.NGUOIDUNGs.FirstOrDefault(s => s.TaiKhoan == user.TaiKhoan);
                var checkEmail = db.NGUOIDUNGs.FirstOrDefault(s => s.Email == user.Email);
                if (checkEmail != null)
                {
                    ViewBag.error1 = "Email này đã tồn tại!";
                }
                if (checkAccout == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NGUOIDUNGs.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    ViewBag.error = "Tên tài khoản này đã tồn tại!";
                    return View();
                }
            }
            return View();
        }
    }
}