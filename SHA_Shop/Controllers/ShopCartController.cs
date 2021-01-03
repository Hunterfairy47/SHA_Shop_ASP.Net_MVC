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
        SHAshopDB db = new SHAshopDB();
        
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

        //Xây dưng trang giỏ hàng
        public ActionResult Index() 
        {
            List<ShopCart> lsCart = GetShopCart();
            if (lsCart.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.SubTotal = SubTotal();
            return View(lsCart);
        }

     
    }
}