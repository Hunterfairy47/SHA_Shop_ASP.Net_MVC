using SHA_Shop.Areas.Admin.Attributtes;
using SHA_Shop.Areas.Admin.Models;
using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SHA_Shop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private SHAContextDB db;
        public UserController()
        {
            db = new SHAContextDB();
        }

        

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            if(User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Index", "MainAdmin");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            var model = new UserLogin();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                var account = db.Administrators.FirstOrDefault(x => x.MatKhau == model.Password && x.IDAdmin == model.Username);

                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "MainAdmin");
                    }
                    else
                    {
                        return Redirect(model.ReturnUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("invalid_account", "tài khoản hoặc mật khẩu chưa đúng");
                }
            }

            return View(model);
        }



        [AdminAuthorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
