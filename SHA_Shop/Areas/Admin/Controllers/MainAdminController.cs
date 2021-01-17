using SHA_Shop.Areas.Admin.Attributtes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Areas.Admin.Controllers
{
    public class MainAdminController : Controller
    {
        [AdminAuthorize]
        // GET: Admin/MainAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}
