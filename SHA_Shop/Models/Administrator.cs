namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        [Key]
        [StringLength(30)]
        public string IDAdmin { get; set; }

        [StringLength(10)]
        public string MatKhau { get; set; }
    }
}
