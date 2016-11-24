namespace Aroma_Restaurent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AromaContext : DbContext
    {
        public AromaContext()
            : base("name=AromaConnection")
        {
        }

        public virtual DbSet<Cake> Cakes { get; set; }
        public virtual DbSet<Cooky> Cookies { get; set; }
        public virtual DbSet<Pastry> Pastries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Cooky>()
                .Property(e => e.Item)
                .IsFixedLength();

            modelBuilder.Entity<Cooky>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Cooky>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Pastry>()
                .Property(e => e.Item)
                .IsFixedLength();

            modelBuilder.Entity<Pastry>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Pastry>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
