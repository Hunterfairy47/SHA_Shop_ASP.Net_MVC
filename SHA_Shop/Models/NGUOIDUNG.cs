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

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập Tài khoản!")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string MatKhau { get; set; }

        [NotMapped]
        [Compare("MatKhau")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
        public string NhapLaiMatKhau { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        public string Email { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại!")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
