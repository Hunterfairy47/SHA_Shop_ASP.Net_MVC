using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class EditSlideFormModel
    {
        public int IDSlide { get; set; }
        public HttpPostedFileBase SlideImage { get; set; } // them hinh anh
        public int? Sapxep { get; set; }
        public String Link { get; set; }
        public String Mota { get; set; }

        public String slideCu { get; set; }
    }
}