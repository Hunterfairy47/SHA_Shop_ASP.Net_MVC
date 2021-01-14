using SHA_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Controllers
{
    public class ShopCartController : Controller
    {
        SHAContextDB db = new SHAContextDB();
        
        //Lấy giỏ hàng
        public List<ShopCart> GetShopCart()
        {
            List<ShopCart> lsCart = Session["ShopCart"] as List<ShopCart>;
            if (lsCart == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì khởi tạo list
                lsCart = new List<ShopCart>();
                Session["ShopCart"] = lsCart;
            }
            return lsCart;
        }

        //Thêm giỏ hàng
        public ActionResult AddShopCart(int iMaSP, string strURL) 
        {
            //Lấy ra session ShopCart
            List<ShopCart> lsCart = GetShopCart();
            //Kiểm tra sản phẩm này tồn tại trong session["ShopCart"] chưa?
            ShopCart sp = lsCart.Find(n => n.iMaSP == iMaSP);
            if (sp == null)
            {
                sp = new ShopCart(iMaSP);
                lsCart.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.iSoLuong++;
                return Redirect(strURL);
            }
        }


        //Tổng số lượng
        private double TotalQuantity()
        {
            double iTotal = 0;
            List<ShopCart> lsCart = Session["ShopCart"] as List<ShopCart>;
            if (lsCart != null)
            {
                iTotal = lsCart.Sum(n => n.iSoLuong);
            }
            return iTotal;
        }

        //Tổng tiền
        private double SubTotal()
        {
            double iSubTotal = 0;
            List<ShopCart> lsCart = Session["ShopCart"] as List<ShopCart>;
            if (lsCart != null)
            {
                iSubTotal = lsCart.Sum(n => n.dThanhTien);
            }
            return iSubTotal;
        }


        //PartialView để hiển thị giỏ hàng
        public ActionResult ShopCartPartial() 
        {
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.SubTotal = SubTotal();
            return PartialView();
        }

        //Xóa giỏ hàng
        public ActionResult DeleteShopCart(int iMaSp)
        {
            //Lấy giỏ hàng từ session
            List<ShopCart> listShopCart = GetShopCart();
            //Kiểm tra đã có trong Session ["ShopCart"]
            ShopCart sp = listShopCart.SingleOrDefault(n => n.iMaSP == iMaSp);
            if (sp !=  null)
            {
                listShopCart.RemoveAll(n => n.iMaSP == iMaSp);
                return RedirectToAction("Index", "ShopCart");
            }
            if (listShopCart.Count == 0)
            {
                return RedirectToAction("Index", "ShopCart");
            }
            return RedirectToAction("Index", "ShopCart");
        }

        //Cập nhật giỏ hàng
        public ActionResult UpdateShopCart(int iMaSP, FormCollection f)
        {
            //Lấy giỏ hàng từ session
            List<ShopCart> listShopCart = GetShopCart();
            //Kiểm tra đã có trong Session ["ShopCart"]
            ShopCart sp = listShopCart.SingleOrDefault(n => n.iMaSP == iMaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Index", "ShopCart");
        }

        //Giỏ null
        public ActionResult ShopCartNull()
        {
            return View();
        }


        //Xây dưng trang giỏ hàng
        public ActionResult Index() 
        {
            List<ShopCart> lsCart = GetShopCart();
            if (lsCart.Count == 0)
            {
                return RedirectToAction("ShopCartNull", "ShopCart");
            }
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.SubTotal = SubTotal();
            return View(lsCart);
        }


        //Hiển thị view CheckOut để cập nhật các thông tin cho đơn hàng
        [HttpGet]
        public ActionResult CheckOut()
        {
            //Kiểm tra đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "User");
            }
            if (Session["ShopCart"] == null)
            {
                return RedirectToAction("Index", "Product");
            }
            
            //Lấy giỏ hàng từ session
            List<ShopCart> listShopCart = GetShopCart();
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.SubTotal = SubTotal();

            return View(listShopCart);
        }

        [HttpPost]
        public ActionResult CheckOut(FormCollection collection) 
        {
            // Thêm đơn hàng
            DONHANG dh = new DONHANG();
            NGUOIDUNG kh = (NGUOIDUNG)Session["TaiKhoan"];
            List<ShopCart> sc = GetShopCart();
            dh.IDNguoiDung = kh.IDNguoiDung;
            dh.NgayDatHang = DateTime.Now;
            var ngaygiao = String.Format("{0:mm/dd/yyy}", collection["NgayGiaoHang"]);
            dh.NgayGiaoHang = DateTime.Parse(ngaygiao);
            dh.TrangThai = false;
            db.DONHANGs.Add(dh);
            db.SaveChanges();

            //thêm chi tiết đơn hàng
            foreach (var item in sc)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MaDH = dh.MaDH;
                ctdh.MaSP = item.iMaSP;
                ctdh.SoLuong = item.iSoLuong;
                ctdh.TongTien = (decimal)item.dThanhTien;
                db.CHITIETDONHANGs.Add(ctdh);       
            }
            db.SaveChanges();
            Session["ShopCart"] = null;
            return RedirectToAction("ConfirmOrder", "ShopCart");
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}