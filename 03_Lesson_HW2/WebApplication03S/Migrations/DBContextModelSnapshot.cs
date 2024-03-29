﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication03HW2.Models;

#nullable disable

namespace WebApplication03HW2.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication03HW2.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("StoreDescription");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("StoreName");

                    b.HasKey("Id")
                        .HasName("StoreID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Stores", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
