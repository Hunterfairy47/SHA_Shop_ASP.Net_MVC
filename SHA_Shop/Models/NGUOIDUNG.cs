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

        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất phải 6 ký tự")]
        public string MatKhau { get; set; }

        [NotMapped]
        [Required( ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu nhập lại không khớp")]
        [StringLength(17)]
        public string NhapLaiMatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(250)]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [StringLength(250)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(13)]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
