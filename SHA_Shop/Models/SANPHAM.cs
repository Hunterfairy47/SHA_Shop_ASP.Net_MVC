namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            KHUYENMAIs = new HashSet<KHUYENMAI>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(250)]
        public string TenSP { get; set; }

        [StringLength(250)]
        public string Anh { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        public decimal? GiaSP { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayDangSP { get; set; }

        public DateTime? TopHot { get; set; }

        public int MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHUYENMAI> KHUYENMAIs { get; set; }
    }
}
