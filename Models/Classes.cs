namespace CapStone.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Classes : DbContext
    {
        public Classes()
            : base("name=Class")
        {
        }

        public virtual DbSet<Class> Class { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
