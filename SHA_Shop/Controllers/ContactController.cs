using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHA_Shop.Models;

namespace SHA_Shop.Controllers
{
    public class ContactController : Controller
    {
        SHAshopDB db = new SHAshopDB();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LIENHE lienhe)
        {

            if (ModelState.IsValid)
            {           
                //Lưu lời nhắn
                LIENHE lh = new LIENHE();
                lh.Ten = lienhe.Ten;
                lh.SDT = lienhe.SDT;
                lh.Email = lienhe.Email;
                lh.NoiDung = lienhe.NoiDung;
                lh.NgayLH = DateTime.Now;
                lh.TrangThai = false;
                db.LIENHEs.Add(lh);
                db.SaveChanges();
                ViewBag.suscess = "Gửi lời nhắn thành công";

            }
                return View();
        }
    }
}