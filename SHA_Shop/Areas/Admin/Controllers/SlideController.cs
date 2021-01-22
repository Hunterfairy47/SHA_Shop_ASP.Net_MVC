using SHA_Shop.Areas.Admin.Models;
using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        SHAContextDB db = new SHAContextDB();
        
        [HttpGet]
        public ActionResult Index()
        {
            var slide = db.SLIDEs.ToList();
            return View(slide);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateSlideFormModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateSlideFormModel model)
        {
            if (ModelState.IsValid)
            {
                var slide = new SLIDE();
                slide.IDSlide = model.IDSlide;
                slide.Sapxep = model.Sapxep;
                slide.Link = model.Link;
                slide.NgayTao = DateTime.Now;

                if (model.SlideImage != null)
                {
                    var fileName = model.SlideImage.FileName;
                    var link = "/uploads/" + fileName;
                    var real = Server.MapPath("~" + link);
                    model.SlideImage.SaveAs(real);
                    slide.Anh = link;
                }
                try
                {
                        db.SLIDEs.Add(slide);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("save_error", "Lỗi khi lưu" + ex.Message);
                    return View(model);
                }
                return RedirectToAction("Index", "Slide");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var slide = db.SLIDEs.FirstOrDefault(m => m.IDSlide == id);
            if (slide == null)
            {
                RedirectToAction("Index", "Slide");
            }
            var chinhsua = new EditSlideFormModel();
            chinhsua.IDSlide= slide.IDSlide;
            //chinhsua.ProductImage = sanpham.ProductImage;
            chinhsua.Link = slide.Link;
            chinhsua.Sapxep = slide.Sapxep;
            chinhsua.slideCu = slide.Anh;
            return View(chinhsua);
        }

        [HttpPost]
        public ActionResult Edit(EditSlideFormModel model)
        {
            if (ModelState.IsValid)
            {
                var slide = db.SLIDEs.FirstOrDefault(m => m.IDSlide == model.IDSlide);
                if (slide != null)
                {
                    slide.IDSlide = model.IDSlide;
                    slide.Sapxep = model.Sapxep;
                    slide.Link = model.Link;
                    //chua chinh anh
                    if (model.SlideImage != null)
                    {
                        var fileName = model.SlideImage.FileName;
                        var link = "/uploads/" + fileName;
                        var real = Server.MapPath("~" + link);
                        model.SlideImage.SaveAs(real);

                        slide.Anh = link;
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Slide");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var slide = db.SLIDEs.FirstOrDefault(m => m.IDSlide == id);
            if (slide == null)
            {
                return RedirectToAction("Index", "Order");
            }
            var xoa = new DeleteSlideFormModel();
            xoa.IDSlide = slide.IDSlide;
            return View(xoa);
        }

        [HttpPost]
        public ActionResult Delete(DeleteSlideFormModel model)
        {
            var slide = db.SLIDEs.FirstOrDefault(m => m.IDSlide == model.IDSlide);
            if (slide == null)
            {
                return RedirectToAction("Index", "Slide");
            }

            db.SLIDEs.Remove(slide);

            db.SaveChanges();

            return RedirectToAction("Index", "Slide");
        }

    }
}
