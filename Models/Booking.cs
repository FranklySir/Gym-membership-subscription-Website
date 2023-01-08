namespace CapStone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Class Booked")]
        [Required]
        [StringLength(50)]
        public string Class_Booked { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int NoOfPeople { get; set; }
    }
}
