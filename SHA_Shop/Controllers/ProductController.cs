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
        SHAContextDB db = new SHAContextDB();
        // GET: ShopProduct
        public ActionResult Index()
        {
            return View();
        }
        //SANG
        // List Product, Tìm kiếm
        public PartialViewResult ListProduct(string search, int? page, int? category)
        {
            var SANPHAM = from p in db.SANPHAMs select p;
            if (!string.IsNullOrEmpty(search))
            {
                SANPHAM = SANPHAM.Where(s => s.TenSP.Contains(search) || s.DANHMUC.TenDM.Contains(search));               
            }
           
            var pageNumber = page ?? 1;
            var pageSize = 9;
            if (category != null)
            {
                ViewBag.category = category;
                SANPHAM = SANPHAM.OrderByDescending(x => x.MaSP).Where(x => x.MaDM == category);
                return PartialView(SANPHAM.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                SANPHAM = SANPHAM.OrderByDescending(x => x.MaSP);
                return PartialView(SANPHAM.ToPagedList(pageNumber, pageSize));
            }
        }

        //Chi tiết sản phẩm
        public ActionResult ProductDetail(int? id)
        {
            SANPHAM sp = db.SANPHAMs.Find(id);
            return View(sp);
        }

        //Danh mục sản phẩm
        public ActionResult CategoryProduct(int id)
        {
            var sp = from s in db.SANPHAMs where s.MaDM == id select s;
            return View(sp);
        }


        // Sản phẩm giảm giá
        //public PartialViewResult SaleProduct(int? id)
        //{
        //    SANPHAM sp = db.SANPHAMs.Find(id);
        //    return View();
        //}
    }
}
