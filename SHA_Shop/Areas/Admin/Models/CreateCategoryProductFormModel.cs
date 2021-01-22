using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class CreateCategoryProductFormModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập danh mục")]
        public int MaDM { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục")]
        public String TenDM { get; set; }

        public int Sapxep { get; set; }

        //public DateTime Ngaytao {get;set;}

    }
}