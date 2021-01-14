namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        public int IDNguoiDung { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(17)]
        public string MatKhau { get; set; }

        [NotMapped]
        [Required]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        [StringLength(17)]
        public string NhapLaiMatKhau { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(13)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
