namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [Key]
        public int MaKM { get; set; }

        [StringLength(200)]
        public string TenKM { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public decimal? DonGia { get; set; }

        public int MaSP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
