using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class EditOrderFormModel
    {

        public int MaDH { get; set; }

        public String NgayGiaoHang { get; set; }

        public bool? TrangThai { get; set; }

        public int IDNguoiDung { get; set; }
    }
}