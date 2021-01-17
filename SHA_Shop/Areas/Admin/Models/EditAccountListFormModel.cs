using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class EditAccountListFormModel
    {
        public int IDNguoiDung { get; set; }
        public String TaiKhoan { get; set; }
        public String Ten { get; set; }
        public String DiaChi { get; set; }
        public String SDT { get; set; }
        public String Email { get; set; }
    }
}