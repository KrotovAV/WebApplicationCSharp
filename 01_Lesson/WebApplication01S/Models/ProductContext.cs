using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace WebApplication01S.Models
{
    public class ProductContext : DbContext
    {

        public DbSet<Group> Group { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Store { get; set; }

        public ProductContext()
        {

        }
        public ProductContext(DbContextOptions dbc) : base(dbc)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=MySQLavk;database=web_01_seminar;",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(x => x.Id).HasName("ProductID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.HasOne(x => x.Group).WithMany(c => c.Products)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("GroupName");

                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Cost)
                .HasColumnName("Cost")
                .IsRequired();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("ProductGroups");

                entity.HasKey(x => x.Id).HasName("GroupID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                .HasColumnName("GroupName")
                .HasMaxLength(255)
                .IsRequired();
            });


            modelBuilder.Entity<Store>(entity =>
            {

                entity.ToTable("Storage");

                entity.HasKey(x => x.Id).HasName("StoreID");


                entity.Property(e => e.Name)
                .HasColumnName("StorageName");

                entity.Property(e => e.Count)
                .HasColumnName("ProductCount");


                entity.HasMany(x => x.Products)
                .WithMany(m => m.Stores)
                .UsingEntity(j => j.ToTable("StorageProduct"));
            });





        }
    }
}
