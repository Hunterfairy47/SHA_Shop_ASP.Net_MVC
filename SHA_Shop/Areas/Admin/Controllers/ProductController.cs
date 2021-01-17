using SHA_Shop.Areas.Admin.Attributtes;
using SHA_Shop.Areas.Admin.Models;
using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using PagedList;
//using PagedList.Mvc;

namespace SHA_Shop.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class ProductController : Controller
    {
        SHAContextDB db = new SHAContextDB();

        [HttpGet]
        public ActionResult Index(string searchkey = "", int page = 1)
        {
            int pagesize = 3;
            double totalItems = db.SANPHAMs.Where(x => x.TenSP.Contains(searchkey)).Count();
            int totalPages = (int)Math.Ceiling(totalItems / pagesize);


            var model = new Paging<SANPHAM>();
            model.TotalItems = (int)totalItems;
            model.TotalPages = totalPages;
            model.PageSize = pagesize;
            model.CurrentPage = page;
            model.Items = db.SANPHAMs.Where(x => x.TenSP.Contains(searchkey)).OrderByDescending(m=> m.NgayDangSP).Skip((page - 1) * pagesize).Take(pagesize).ToList();


            ViewBag.searchkey = searchkey;

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateProductFormModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateProductFormModel model)
        {
            if (ModelState.IsValid)
            {
                var sp = new SANPHAM();
                sp.MaSP = model.MaSP;
                sp.TenSP = model.TenSP;
                //sp.Anh = model.Anh;
                sp.MoTa = model.MoTa;
                sp.ChiTiet = model.ChiTiet;
                sp.SoLuong = model.SoLuong;
                sp.NgayDangSP = DateTime.Now;
                sp.MaDM = model.MaDM;
  

                sp.MaDM = model.MaDM;
                if (model.ProductImage != null)
                {
                    var fileName = model.ProductImage.FileName;
                    var link = "/uploads/" + fileName;
                    var real = Server.MapPath("~" + link);
                    model.ProductImage.SaveAs(real);

                    sp.Anh = link;
                }
                try
                {
                    db.SANPHAMs.Add(sp);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("save_error", "Lỗi khi lưu" + ex.Message);
                    return View(model);
                }
                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int masp /*,HttpPostedFileBase ProductImage*/)
        {
            var sanpham = db.SANPHAMs.FirstOrDefault(m => m.MaSP == masp);
            if (sanpham == null)
            {
                RedirectToAction("Index", "Product");
            }
            var chinhsua = new EditProductFormModel();
            chinhsua.TenSP = sanpham.TenSP;
            //chinhsua.ProductImage = sanpham.ProductImage;
            chinhsua.MoTa = sanpham.MoTa;
            chinhsua.ChiTiet = sanpham.ChiTiet;
            chinhsua.GiaSP = sanpham.GiaSP;
            chinhsua.SoLuong = sanpham.SoLuong;
            chinhsua.MaDM = sanpham.MaDM;
            chinhsua.hinhCu = sanpham.Anh;

            return View(chinhsua);
        }

        [HttpPost]
        public ActionResult Edit(EditProductFormModel model)
        {
            if (ModelState.IsValid)
            {
                var sanpham = db.SANPHAMs.FirstOrDefault(m => m.MaSP == model.MaSP);
                if (sanpham != null)
                {
                    sanpham.MaSP = model.MaSP;
                    sanpham.TenSP = model.TenSP;
                    sanpham.MoTa = model.MoTa;
                    //chua chinh anh
                    sanpham.ChiTiet = model.ChiTiet;
                    sanpham.GiaSP = model.GiaSP;
                    sanpham.SoLuong = model.SoLuong;
                    sanpham.MaDM = model.MaDM;

                    if (model.ProductImage != null)
                    {
                        var fileName = model.ProductImage.FileName;
                        var link = "/uploads/" + fileName;
                        var real = Server.MapPath("~" + link);
                        model.ProductImage.SaveAs(real);

                        sanpham.Anh = link;
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int masp)
        {
            var sanpham = db.SANPHAMs.FirstOrDefault(m => m.MaSP == masp);
            if (sanpham == null)
            {
                return RedirectToAction("Index", "Product");
            }

            var xoa = new DeleteProductFormModel();
            xoa.MaSP = sanpham.MaSP;
            xoa.TenSP = sanpham.TenSP;
            return View(xoa);
        }

        [HttpPost]
        public ActionResult Delete(DeleteProductFormModel model)
        {
            var sanpham = db.SANPHAMs.FirstOrDefault(m => m.MaSP == model.MaSP);
            if (sanpham == null)
            {
                return RedirectToAction("Index", "Product");
            }

            db.SANPHAMs.Remove(sanpham);

            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}
