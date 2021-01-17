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
    public class ContactController : Controller
    {
        SHAContextDB db = new SHAContextDB();

        [HttpGet]
        public ActionResult Index()
        {
            var lienhe= db.LIENHEs.ToList();
            return View(lienhe);
        }

       
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lienhe = db.LIENHEs.FirstOrDefault(m => m.ID == id);
            if (lienhe == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            var xoa = new DeleteContactFormModel();
            xoa.IDLienHe= lienhe.ID;
            return View(xoa);
        }

        [HttpPost]
        public ActionResult Delete(DeleteContactFormModel model)
        {
            var lienhe = db.LIENHEs.FirstOrDefault(m => m.ID == model.IDLienHe);
            if (lienhe == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            db.LIENHEs.Remove(lienhe);

            db.SaveChanges();

            return RedirectToAction("Index", "Contact");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lienhe = db.LIENHEs.FirstOrDefault(m => m.ID == id);
            if (lienhe == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            var chinhsua = new EditContact();
            //chinhsua.trangthai = (bool)lienhe.trangthai;
            return View(chinhsua);
        }

        [HttpPost]
        public ActionResult Edit(EditContact model)
        {            
            if (ModelState.IsValid)
            {
                var lienhe = db.LIENHEs.FirstOrDefault(m => m.ID == model.id);
                if (lienhe != null)
                {
                    lienhe.TrangThai = true;                          
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Contact");
            }
            return View(model);
        }
    }
}
