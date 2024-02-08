﻿// <auto-generated />
using Billing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Billing.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240208070936_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Billing.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PhNo")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Name = "John Doe",
                            PhNo = 1234567890L,
                            email = "john@example.com"
                        },
                        new
                        {
                            CustomerId = 2,
                            Name = "Jane Smith",
                            PhNo = 9876543210L,
                            email = "jane@example.com"
                        });
                });

            modelBuilder.Entity("Billing.Models.Invoice", b =>
                {
                    b.Property<long>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("InvoiceId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1L,
                            CustomerId = 1
                        },
                        new
                        {
                            InvoiceId = 2L,
                            CustomerId = 2
                        });
                });

            modelBuilder.Entity("Billing.Models.InvoiceProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<long>("InvoiceId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InvoiceId = 1L,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            InvoiceId = 1L,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            InvoiceId = 2L,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("Billing.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Product A",
                            Price = 10.50m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Product B",
                            Price = 20.75m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Product C",
                            Price = 20.75m
                        });
                });

            modelBuilder.Entity("Billing.Models.Invoice", b =>
                {
                    b.HasOne("Billing.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Billing.Models.InvoiceProduct", b =>
                {
                    b.HasOne("Billing.Models.Invoice", "Invoice")
                        .WithMany("InvoiceProducts")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Billing.Models.Product", "Product")
                        .WithMany("InvoiceProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Billing.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Billing.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceProducts");
                });

            modelBuilder.Entity("Billing.Models.Product", b =>
                {
                    b.Navigation("InvoiceProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
