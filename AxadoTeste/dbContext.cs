namespace AxadoTeste.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<Carrier> Carrier { get; set; }
        public virtual DbSet<CarrierRating> CarrierRating { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .HasMany(e => e.CarrierRating)
                .WithRequired(e => e.Carrier)
                .HasForeignKey(e => e.id_Carrier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarrierRating>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CarrierRating>()
                .Property(e => e.id_Carrier)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CarrierRating>()
                .Property(e => e.id_User)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CarrierRating)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.id_User)
                .WillCascadeOnDelete(false);
        }
    }
}
