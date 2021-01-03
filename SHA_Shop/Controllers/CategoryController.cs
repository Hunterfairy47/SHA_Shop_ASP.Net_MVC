using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHA_Shop.Models;

namespace SHA_Shop.Controllers
{
    public class CategoryController : Controller
    {
        SHAshopDB db = new SHAshopDB();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.DANHMUCs.OrderBy(x=> x.Sapxep).ToList());
        }

        public PartialViewResult CategoryPartial()
        {
            var categoryList = db.DANHMUCs.OrderBy(x => x.TenDM).ToList();
            return PartialView(categoryList);
        }
    }
}