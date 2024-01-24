﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication03HW3.Models;

#nullable disable

namespace WebApplication03HW3.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240124002337_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication03HW3.Models.ProdInStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("ProductCount");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("IdStore")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.HasKey("Id")
                        .HasName("ID");

                    b.ToTable("ProdsInStores", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}