using SHA_Shop.Areas.Admin.Attributtes;
using SHA_Shop.Areas.Admin.Models;
using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class OrderController : Controller
    {
        SHAContextDB db = new SHAContextDB();

        [HttpGet]
        public ActionResult Index()
        {
            var donhang = db.DONHANGs.ToList();
            return View(donhang);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            DONHANG donhang = db.DONHANGs.SingleOrDefault(m => m.MaDH == id);
            var list = db.CHITIETDONHANGs.Where(m => m.MaDH == id).ToList();

            ViewBag.list = list;
            if (donhang == null)
            {
                return RedirectToAction("Index", "Order");
            }
            return View(donhang);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var donhang = db.DONHANGs.FirstOrDefault(m => m.MaDH == id);
            if (donhang == null)
            {
                return RedirectToAction("Index", "Order");
            }

            var chinhsua = new EditOrderFormModel();
            chinhsua.MaDH = donhang.MaDH;
            if (donhang.TrangThai.HasValue)
            {
                chinhsua.TrangThai = donhang.TrangThai.Value;
            }


            if (donhang.NgayGiaoHang.HasValue)
            {
                chinhsua.NgayGiaoHang = donhang.NgayGiaoHang.Value.ToString("dd/MM/yyyy");
            }
            chinhsua.IDNguoiDung = donhang.IDNguoiDung;
            return View(chinhsua);
        }

        [HttpPost]
        public ActionResult Edit(EditOrderFormModel model)
        {
            if (ModelState.IsValid)
            {
                var donhang = db.DONHANGs.FirstOrDefault(m => m.MaDH == model.MaDH);
                if (donhang != null)
                {
                    donhang.MaDH = model.MaDH;
                    donhang.TrangThai = model.TrangThai;
                    try
                    {
                        donhang.NgayGiaoHang = DateTime.ParseExact(model.NgayGiaoHang, "dd/MM/yyyy", null);
                    }
                    catch { }
                    //donhang.NgayGiaoHang = model.NgayGiaoHang;
                    donhang.IDNguoiDung = model.IDNguoiDung;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Order");
            }
            return View(model);
        }


     
    }
}
