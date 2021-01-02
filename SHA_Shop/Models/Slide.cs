namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDE")]
    public partial class SLIDE
    {
        [Key]
        public int IDSlide { get; set; }

        [StringLength(250)]
        public string Anh { get; set; }

        public int? Sapxep { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(500)]
        public string Mota { get; set; }

        public DateTime? NgayTao { get; set; }
    }
}
