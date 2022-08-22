using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MSSQL
{
    public partial class Connection : DbContext
    {
        public Connection()
            : base("name=Connection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<React> Reacts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UniqueID)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Reacts)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.AccountID);

            modelBuilder.Entity<Product>()
                .Property(e => e.PICTURE)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.React)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Reacts)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<React>()
                .Property(e => e.UniqueID)
                .IsUnicode(false);

            modelBuilder.Entity<React>()
                .Property(e => e.AccountID)
                .IsUnicode(false);
        }
    }
}
