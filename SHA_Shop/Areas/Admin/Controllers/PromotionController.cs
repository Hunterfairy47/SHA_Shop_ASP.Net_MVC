using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Areas.Admin.Controllers
{
    public class PromotionController : Controller
    {
        // GET: Admin/Promotion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Promotion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Promotion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Promotion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
