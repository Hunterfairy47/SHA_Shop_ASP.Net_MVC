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
        public ActionResult Details(int id = 0)
        {
            DONHANG chitiet = db.DONHANGs.Find(id);
            return View(chitiet);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var donhang = db.DONHANGs.Find(id);
            if (donhang == null)
            {
                return RedirectToAction("Index", "Order");
            }
            var chinhsua = new EditOrderFormModel();
            //chinhsua.NgayGiaoHang = donhang.NgayGiaoHang.ToString("dd/MM/yyyy");


            return View(chinhsua);
        }
        [HttpPost]
        public ActionResult Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                var donhang = db.DONHANGs.Find(id);
                if (donhang != null)
                {

                    donhang.NgayGiaoHang = donhang.NgayGiaoHang;
                    donhang.TrangThai = donhang.TrangThai;

                    db.SaveChanges();
                    return RedirectToAction("Index", "Oder");
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var donhang = db.DONHANGs.FirstOrDefault(m => m.MaDH == id);
            if (donhang == null)
            {
                return RedirectToAction("Index", "Order");
            }
            var xoa = new DeleteOrderFormModel();
            xoa.MaDH = donhang.MaDH;

            return View(xoa);
        }
        [HttpPost]
        public ActionResult Delete(DeleteOrderFormModel model)
        {
            var donhang = db.DONHANGs.FirstOrDefault(m => m.MaDH == model.MaDH);
            if (donhang == null)
            {
                return RedirectToAction("Index", "Order");
            }

            db.DONHANGs.Remove(donhang);

            db.SaveChanges();

            return RedirectToAction("Index", "Order");
        }

    }
}
