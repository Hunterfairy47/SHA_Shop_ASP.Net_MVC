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
        SHAContextDB db = new SHAContextDB();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryPartial()
        {
            var categoryList = db.DANHMUCs.OrderBy(x => x.MaDM).ToList();
            return PartialView(categoryList);
        }
    }
}