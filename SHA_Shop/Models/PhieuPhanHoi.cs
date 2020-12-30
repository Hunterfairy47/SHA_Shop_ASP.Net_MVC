namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuPhanHoi")]
    public partial class PhieuPhanHoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieu { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(17)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(500)]
        public string LoiNhan { get; set; }
    }
}
