//using SHA_Shop.Areas.Admin.Attributtes;
//using SHA_Shop.Areas.Admin.Models;
//using SHA_Shop.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace SHA_Shop.Areas.Admin.Controllers
//{
//    [AdminAuthorize]
//    public class FeedbackController : Controller
//    {
//        SHAContextDB db = new SHAContextDB();

//        [HttpGet]
//        //public ActionResult Index()
//        //{
//        //    var taikhoan = db.NGUOIDUNGs.ToList();
//        //    return View(taikhoan);
//        //}

//        public ActionResult Index(string searchkey = "")
//        {
//            var list = db.PhieuPhanHois.Where(x => x.Ten.Contains(searchkey)).ToList();

//            ViewBag.searchkey = searchkey;
//            return View(list);
//        }



//        [HttpGet]
//        public ActionResult Delete(int id)
//        {
//            var phanhoi = db.PhieuPhanHois.FirstOrDefault(m => m.MaPhieu == id);
//            if (phanhoi == null)
//            {
//                return RedirectToAction("Index", "Feedback");
//            }

//            var xoa = new DeleteFeedbackFormModel();
//            xoa.MaPhieu = phanhoi.MaPhieu;
//            xoa.Ten = phanhoi.Ten;
//            return View(xoa);
//        }

//        [HttpPost]
//        public ActionResult Delete(DeleteFeedbackFormModel model)
//        {
//            var phanhoi = db.PhieuPhanHois.FirstOrDefault(m => m.MaPhieu == model.MaPhieu);
//            if (phanhoi == null)
//            {
//                return RedirectToAction("Index", "Feedback");
//            }

//            db.PhieuPhanHois.Remove(phanhoi);

//            db.SaveChanges();

//            return RedirectToAction("Index", "Feedback");
//        }


//    }
//}
