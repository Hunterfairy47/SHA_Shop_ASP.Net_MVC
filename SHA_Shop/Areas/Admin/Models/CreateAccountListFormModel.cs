using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    
    public class CreateAccountListFormModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập ID")]
        public int IDNguoiDung { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản")]
        public String TaiKhoan { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu ")]
        public String NhapLaiMatKhau { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public String MatKhau { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        public String Ten { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public String DiaChi { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public String SDT { get; set; }
        public String Email { get; set; }
    }
}