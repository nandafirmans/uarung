﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uarung.Data.Provider;

namespace Uarung.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180923185600_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Uarung.Data.Entity.Discount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Uarung.Data.Entity.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Uarung.Data.Entity.ProductCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Uarung.Data.Entity.ProductImage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ProductId");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Uarung.Data.Entity.SelectedProduct", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Notes");

                    b.Property<string>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("TransactionId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionId");

                    b.ToTable("SelectedProducts");
                });

            modelBuilder.Entity("Uarung.Data.Entity.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DiscountCode");

                    b.Property<string>("PaymentStatus");

                    b.Property<string>("PaymentType");

                    b.Property<decimal>("TotalPrice");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Uarung.Data.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Role");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Uarung.Data.Entity.Discount", b =>
                {
                    b.HasOne("Uarung.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Uarung.Data.Entity.Product", b =>
                {
                    b.HasOne("Uarung.Data.Entity.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Uarung.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Uarung.Data.Entity.ProductImage", b =>
                {
                    b.HasOne("Uarung.Data.Entity.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Uarung.Data.Entity.SelectedProduct", b =>
                {
                    b.HasOne("Uarung.Data.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Uarung.Data.Entity.Transaction", "Transaction")
                        .WithMany("SelectedProducts")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("Uarung.Data.Entity.Transaction", b =>
                {
                    b.HasOne("Uarung.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
