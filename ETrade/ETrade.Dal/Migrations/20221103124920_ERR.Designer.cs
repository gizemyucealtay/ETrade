﻿// <auto-generated />
using System;
using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETrade.Dal.Migrations
{
    [DbContext(typeof(TradeContext))]
    [Migration("20221103124920_ERR")]
    partial class ERR
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ETrade.Entity.Concretes.BasketDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Ratio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id", "ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitId");

                    b.ToTable("BasketDetail");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("BasketMaster");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Error")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Vat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Ratio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Vat");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.BasketDetail", b =>
                {
                    b.HasOne("ETrade.Entity.Concretes.BasketMaster", "BasketMaster")
                        .WithMany("BasketDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETrade.Entity.Concretes.Products", "Products")
                        .WithMany("BasketDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETrade.Entity.Concretes.Unit", "Unit")
                        .WithMany("BasketDetail")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasketMaster");

                    b.Navigation("Products");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.HasOne("ETrade.Entity.Concretes.Users", "Users")
                        .WithMany("BasketMaster")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.County", b =>
                {
                    b.HasOne("ETrade.Entity.Concretes.City", "City")
                        .WithMany("Counties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Products", b =>
                {
                    b.HasOne("ETrade.Entity.Concretes.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETrade.Entity.Concretes.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Users", b =>
                {
                    b.HasOne("ETrade.Entity.Concretes.County", "County")
                        .WithMany("Users")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.Navigation("BasketDetails");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.City", b =>
                {
                    b.Navigation("Counties");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.County", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Products", b =>
                {
                    b.Navigation("BasketDetail");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Unit", b =>
                {
                    b.Navigation("BasketDetail");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ETrade.Entity.Concretes.Users", b =>
                {
                    b.Navigation("BasketMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
