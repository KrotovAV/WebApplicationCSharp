using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using WebApplication03HW3.Models;

namespace WebApplication03HW3.Models
{
    public class DBContext : DbContext
    {
        public DbSet<ProdInStore> ProdInStores { get; set; }

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


            modelBuilder.Entity<ProdInStore>(entity =>
            {

                entity.ToTable("ProdsInStores");

                entity.HasKey(x => x.Id)
                      .HasName("ID");

                entity.Property(e => e.IdStore)
                      .HasColumnName("StoreID")
                      .IsRequired();

                entity.Property(e => e.IdProduct)
                      .HasColumnName("ProductID")
                      .IsRequired();

                entity.Property(e => e.Count)
                      .HasColumnName("ProductCount")
                      .IsRequired();

            });


        }
    }

}
