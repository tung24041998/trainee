namespace Trainee.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db_Trainee : DbContext
    {
        public db_Trainee()
            : base("name=db_Trainee4")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ThemeImage> ThemeImages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Passwork)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwork)
                .IsUnicode(false);
        }
    }
}
