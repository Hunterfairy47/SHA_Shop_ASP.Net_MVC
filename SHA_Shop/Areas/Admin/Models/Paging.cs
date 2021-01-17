using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHA_Shop.Areas.Admin.Models
{
    public class Paging<T>
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int PrevPage { get; set; }
        public int LastPage { get; set; }
        public int FirstPage { get; set; }

        public List<T> Items { get; set; }
    }
}