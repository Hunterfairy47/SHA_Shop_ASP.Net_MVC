using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net;

namespace SHA_Shop.Controllers
{
    public class ProductController : Controller
    {
        SHAshopDB db = new SHAshopDB();
        // GET: ShopProduct
        public ActionResult Index()
        {
            return View();
        }
        //SANG
        // List Product
        public PartialViewResult ListProduct(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 9;
            var listproduct = db.SANPHAMs.OrderByDescending(x => x.MaSP).ToPagedList(pageNumber, pageSize);
            return PartialView(listproduct);
        }

        public  ActionResult ProductDetail(int? id)
        {
            SANPHAM sp = db.SANPHAMs.Find(id);       
            return View(sp);
        }

        public ActionResult CategoryProduct(int id)
        {
            var sp = from s in db.SANPHAMs where s.MaDM == id select s;
            return View(sp);
        }
    }
}
   