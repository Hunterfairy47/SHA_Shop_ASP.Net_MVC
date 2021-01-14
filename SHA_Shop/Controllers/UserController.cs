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
        SHAContextDB db = new SHAContextDB();

        // Đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string TaiKhoan, string MatKhau)
        {
            if (ModelState.IsValid)
            {               
                NGUOIDUNG user = db.NGUOIDUNGs.Where(x => x.TaiKhoan.Equals(TaiKhoan) && x.MatKhau.Equals(MatKhau)).FirstOrDefault();

                if (String.IsNullOrEmpty(TaiKhoan))
                {
                    ViewBag.error1 = "Vui lòng nhập tên tài khoản";
                }
                if (String.IsNullOrEmpty(MatKhau))
                {
                    ViewBag.error2 = "Vui lòng nhập mật khẩu";
                }
                else if (user != null)
                {
                    Session["IDNguoiDung"] = user.IDNguoiDung;
                    Session["TaiKhoan"] = user;
                    Session["Ten"] = user.Ten;
                    ViewBag.message = "Chúc mừng đăng nhập thành công";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Tên đăng nhập hoặc mật khẩu không đúng!";
                    return View("Login");
                }
            }
            return View();
        }
        
        public ActionResult LogOut()
        {
            Session.Clear();
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