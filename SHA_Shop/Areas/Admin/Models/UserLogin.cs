using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class UserLogin
    {
        //private String tendn;
        //private String mk
        
        [Required(ErrorMessage ="Bạn chưa nhập tài khoản")]
        [MaxLength(20, ErrorMessage = "Tài khoản tối đa 20 ký tự")]
        //[MinLength(5,ErrorMessage = "tai khoan toi thieu 6 ky tu")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public String Password { get; set; }


        public string ReturnUrl { get; set; }
    }
}