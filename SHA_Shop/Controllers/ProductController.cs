using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
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

    }
}
        //private List<SANPHAM> layspmoi(int count)
        //{
        //    return db.SANPHAMs.OrderByDescending(x => x.MaSP).Take(count).ToList();
        //}

        ////public ActionResult Products(int? page)
        ////{
        ////    int pageSize = 9;

        ////    int pageNum = (page ?? 1);

        ////    var spmoi = layspmoi(30);
        ////    return View(spmoi.ToPagedList(pageNum, pageSize));
        ////}