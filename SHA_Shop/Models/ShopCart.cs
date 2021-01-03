using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHA_Shop.Models
{
    public class ShopCart
    {
        //Tạo đối tượng DATA chưa dữ liệu từ model db
        SHAshopDB db = new SHAshopDB();

        public int iMaSP { get; set; }

        public string sTenSP { get; set; }

        public string sAnh { get; set; }

        public Double dGiaSP { get; set; }

        public int iSoLuong { get; set; }

        public Double dThanhTien 
        {
            get { return iSoLuong * dGiaSP; }
        }
        //Khởi tạo giỏ hàng theo MaSp được truyền vào với số lương mặc định là 1
        public ShopCart(int MaSP )
        {
            iMaSP = MaSP;
            SANPHAM sp = db.SANPHAMs.Single(n => n.MaSP == MaSP);
            sTenSP = sp.TenSP;
            sAnh = sp.Anh;
            dGiaSP = double.Parse(sp.GiaSP.ToString());
            iSoLuong = 1;
        }
    }
}