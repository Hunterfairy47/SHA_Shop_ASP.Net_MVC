namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENHE")]
    public partial class LIENHE
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(17)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public DateTime? NgayLH { get; set; }

        public bool? TrangThai { get; set; }
    }
}
