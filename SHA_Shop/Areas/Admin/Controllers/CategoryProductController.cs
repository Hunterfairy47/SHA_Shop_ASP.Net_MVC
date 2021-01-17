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
    public class CategoryProductController : Controller
    {
        SHAContextDB db = new SHAContextDB();

        [HttpGet]
        public ActionResult Index(string searchkey = "")
        {
            var list = db.DANHMUCs.Where(x => x.TenDM.Contains(searchkey)).ToList();
            ViewBag.searchkey = searchkey;

            return View(list);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateCategoryProductFormModel();
            return View(model);
        }

        // POST: Admin/CategoryProduct/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryProductFormModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new DANHMUC();
                category.MaDM = model.MaDM;
                category.TenDM = model.TenDM;
                category.Ngaytao = DateTime.Now;

                try
                {
                    db.DANHMUCs.Add(category);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("save_error", "Lỗi khi lưu: "+ex.Message);
                    return View(model);
                }

                return RedirectToAction("Index", "CategoryProduct");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int madm )
        {
            var danhmuc = db.DANHMUCs.FirstOrDefault(m => m.MaDM == madm);
            if (danhmuc == null)
            {
                return RedirectToAction("Index", "CategoryProduct");
            }

            var chinhsua = new EditCategoryProductFormModel();
            chinhsua.TenDM = danhmuc.TenDM;
            chinhsua.MaDM = danhmuc.MaDM;
            return View(chinhsua);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryProductFormModel model)
        {
            if (ModelState.IsValid)
            {
                var danhmuc = db.DANHMUCs.FirstOrDefault(m => m.MaDM == model.MaDM);
                if(danhmuc!=null)
                {
                    danhmuc.TenDM = model.TenDM;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "CategoryProduct");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int madm)
        {
            var danhmuc = db.DANHMUCs.FirstOrDefault(m => m.MaDM == madm);
            if(danhmuc == null)
            {
                return RedirectToAction("Index", "CategoryProduct");
            }

            var xoa = new DeleteCategoryProductFormModel();
            xoa.MaDM = danhmuc.MaDM;
            xoa.TenDM = danhmuc.TenDM;
            return View(xoa);
        }

        [HttpPost]
        public ActionResult Delete(DeleteCategoryProductFormModel model)
        {
            var danhmuc = db.DANHMUCs.FirstOrDefault(m => m.MaDM == model.MaDM);
            if (danhmuc == null)
            {
                return RedirectToAction("Index", "CategoryProduct");
            }

            db.DANHMUCs.Remove(danhmuc);

            db.SaveChanges();

            return RedirectToAction("Index", "CategoryProduct");
        }
    }
}
