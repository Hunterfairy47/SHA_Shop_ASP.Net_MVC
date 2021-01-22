using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class CreateProductFormModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập Mã sản phẩm")]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Tên sản phẩm")]
        public String TenSP { get; set; }
        //public String Anh { get; set; }
        public String MoTa { get; set; }
        public String ChiTiet { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Giá sản phẩm")]
        public decimal? GiaSP { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Số lượng")]
        public int? SoLuong { get; set; }
        public int MaDM { get; set; }

        public HttpPostedFileBase ProductImage { get; set; }
    }
}