namespace CapStone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Class")]
        [Required]
        [StringLength(50)]
        public string Class1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }
    }

}
