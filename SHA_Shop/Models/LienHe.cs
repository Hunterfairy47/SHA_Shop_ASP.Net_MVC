namespace SHA_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLienHe { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }
    }
}
