namespace Trainee
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db_Context : DbContext
    {
        public db_Context()
            : base("name=db_Context")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Image> Images { get; set; }
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
