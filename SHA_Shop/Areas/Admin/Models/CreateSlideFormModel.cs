using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class CreateSlideFormModel
    {
        //[Required(ErrorMessage = "Bạn chưa nhập ID Slide")]
        public int IDSlide{ get; set; }
        //public String Anh { get; set; }
        public int Sapxep { get; set; }
        public String Link{ get; set; }

        //[Required(ErrorMessage = "Bạn chưa nhập Giá sản phẩm")]
        public String Mota{ get; set; }

        //[Required(ErrorMessage = "Bạn chưa nhập thêm ảnh Slide")]
        public HttpPostedFileBase SlideImage { get; set; }
    }
}