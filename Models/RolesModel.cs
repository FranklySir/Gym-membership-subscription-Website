namespace CapStone.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RolesModel : DbContext
    {
        public RolesModel()
            : base("name=RolesModel")
        {
        }

        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(e => e.Role1)
                .IsFixedLength();
        }
    }
}
