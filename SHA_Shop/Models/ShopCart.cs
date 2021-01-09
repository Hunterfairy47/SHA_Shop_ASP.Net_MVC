using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Models
{
    public class ShopCart
    {
        //Tạo đối tượng data chứa dữ liệu từ model SHAshopDB 
        SHAshopDB data = new SHAshopDB();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnh { get; set; }
        public Double dGiaSP { get; set; }
        public int iSoLuong { get; set; }
        public Double dThanhTien
        {
            get { return iSoLuong * dGiaSP; }
        }

        // Khởi tạo giỏ hàng  theo MaSP được truyền vào với SoLuong mặc định là 1
        public ShopCart(int MaSP)
        {
            iMaSP = MaSP;
            SANPHAM sanpham = data.SANPHAMs.Single(n => n.MaSP == iMaSP);
            sTenSP = sanpham.TenSP;
            sAnh = sanpham.Anh;
            dGiaSP = double.Parse(sanpham.GiaSP.ToString());
            iSoLuong = 1;
        }
    }
}