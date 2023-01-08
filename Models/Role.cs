namespace CapStone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int Id { get; set; }

        public int? userId { get; set; }

        [Column("Role")]
        [StringLength(10)]
        public string Role1 { get; set; }
    }
}
