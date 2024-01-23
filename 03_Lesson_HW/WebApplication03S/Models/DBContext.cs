using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using WebApplication03HW.Models;

namespace WebApplication03HW.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }


        public DBContext()
        {

        }
        public DBContext(DbContextOptions dbc) : base(dbc)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();


            optionsBuilder.UseMySql(config.GetConnectionString("Connection"),
                new MySqlServerVersion(new Version(8, 0, 11)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {

                entity.ToTable("Products");

                entity.HasKey(x => x.Id)
                      .HasName("ProductID");

                entity.HasIndex(x => x.Name)
                      .IsUnique();

                entity.HasOne(x => x.Group)
                      .WithMany(c => c.Products)
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

                entity.Property(e => e.Description)
                      .HasColumnName("GroupDescription")
                      .HasMaxLength(255)
                      .IsRequired();
            });

        }
    }

}
