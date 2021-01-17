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
    public class AccountListController: Controller
    {
        SHAContextDB db = new SHAContextDB();

        [HttpGet]
        //public ActionResult Index()
        //{
        //    var taikhoan = db.NGUOIDUNGs.ToList();
        //    return View(taikhoan);
        //}

        public ActionResult Index(string searchkey = "")
        {
            var list = db.NGUOIDUNGs.Where(x => x.Ten.Contains(searchkey)).ToList();
            
            ViewBag.searchkey = searchkey;
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateAccountListFormModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateAccountListFormModel model)
        {
            if (ModelState.IsValid)
            {
                var account = new NGUOIDUNG();
                account.IDNguoiDung = model.IDNguoiDung;
                account.TaiKhoan = model.TaiKhoan;
                account.MatKhau = model.MatKhau;
                account.NhapLaiMatKhau = model.NhapLaiMatKhau;
                account.Ten = model.Ten;
                account.SDT = model.SDT;
                account.DiaChi = model.DiaChi;
                account.Email = model.Email;

                try
                {
                    db.NGUOIDUNGs.Add(account);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("save_error", "Lỗi khi lưu" + ex.Message);
                    return View(model);
                }

                return RedirectToAction("Index", "AccountList");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nguoidung = db.NGUOIDUNGs.FirstOrDefault(m => m.IDNguoiDung == id);
            if (nguoidung == null)
            {
                return RedirectToAction("Index", "AccountList");
            }

            var chinhsua = new EditAccountListFormModel();
            chinhsua.TaiKhoan = nguoidung.TaiKhoan;
            chinhsua.Ten = nguoidung.Ten;
            chinhsua.DiaChi = nguoidung.DiaChi;
            chinhsua.SDT = nguoidung.SDT;
            chinhsua.Email = nguoidung.Email;

            return View(chinhsua);
        }
        [HttpPost]
        public ActionResult Edit(EditAccountListFormModel model)
        {
            if (ModelState.IsValid)
            {
                var nguoidung = db.NGUOIDUNGs.FirstOrDefault(m => m.IDNguoiDung == model.IDNguoiDung);
                if (nguoidung!= null)
                {
                    nguoidung.IDNguoiDung = model.IDNguoiDung;
                    nguoidung.TaiKhoan = model.TaiKhoan;
                    nguoidung.Ten = model.Ten;
                    nguoidung.DiaChi = model.DiaChi;
                    nguoidung.SDT = model.SDT;
                    nguoidung.Email = model.Email;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "AccountList");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nguoidung = db.NGUOIDUNGs.FirstOrDefault(m => m.IDNguoiDung == id);
            if (nguoidung == null)
            {
                return RedirectToAction("Index", "AccountList");
            }

            var xoa = new DeleteAccountListFormModel();
            xoa.IDNguoiDung = nguoidung.IDNguoiDung;
            xoa.TaiKhoan = nguoidung.TaiKhoan;
            return View(xoa);
        }

        [HttpPost]
        public ActionResult Delete(DeleteAccountListFormModel model)
        {
            var nguoidung = db.NGUOIDUNGs.FirstOrDefault(m => m.IDNguoiDung == model.IDNguoiDung);
            if (nguoidung == null)
            {
                return RedirectToAction("Index", "AccountList");
            }

            db.NGUOIDUNGs.Remove(nguoidung);

            db.SaveChanges();

            return RedirectToAction("Index", "AccountList");
        }


    }
}
