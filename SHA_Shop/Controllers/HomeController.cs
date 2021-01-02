using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Controllers
{
    public class HomeController : Controller
    {
        SHAshopDB db = new SHAshopDB();
        public ActionResult Index()
        {
            return View();
        }

        //Lấy ra 5 sản phẩm mới nhất
        public PartialViewResult LatestProducts()
        {
            var latestProducts = db.SANPHAMs.OrderByDescending(x => x.MaSP).Take(5).ToList();
            return PartialView(latestProducts);
        }

        public PartialViewResult HotProducts()
        {
            var hotProducts = db.SANPHAMs.OrderBy(x => x.MaSP).Take(5).ToList();
            return PartialView(hotProducts);
        }
    }
   
}