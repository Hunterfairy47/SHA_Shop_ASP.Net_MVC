using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class EditProductFormModel
    {
        public int MaSP { get; set; }
        public String TenSP { get; set; }
        public String MoTa { get; set; }
        public String ChiTiet { get; set; }
        public decimal? GiaSP { get; set; }
        public int? SoLuong { get; set; }
        public int MaDM { get; set; }
        public String hinhCu { get; set; }

        public HttpPostedFileBase ProductImage { get; set; } // them hinh anh
    }
}