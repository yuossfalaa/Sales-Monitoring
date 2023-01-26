﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_Monitoring.SalesMonitoring.EntityFramework;

#nullable disable

namespace SalesMonitoring.Migrations
{
    [DbContext(typeof(SalesMonitoringDbContext))]
    [Migration("20230126072405_Taxes-Edite")]
    partial class TaxesEdite
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.ItemSales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("InStoreSales")
                        .HasColumnType("REAL");

                    b.Property<int?>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("QtyInStore")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QtySwiggy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QtyZomato")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("SwiggySales")
                        .HasColumnType("REAL");

                    b.Property<double?>("Taxes")
                        .HasColumnType("REAL");

                    b.Property<double?>("ZomatoSales")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ItemSales");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ItemInstorePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("ItemSwiggyPrice")
                        .HasColumnType("REAL");

                    b.Property<double?>("ItemZomatoPrice")
                        .HasColumnType("REAL");

                    b.Property<double?>("TaxesPercentage")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderCollectionId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("TaxesPercentage")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderCollectionId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.OrderCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Discount")
                        .HasColumnType("REAL");

                    b.Property<string>("Payment")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Roundoff")
                        .HasColumnType("REAL");

                    b.Property<double?>("Tax")
                        .HasColumnType("REAL");

                    b.Property<double?>("TotalBill")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderCollection");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.RecordExpenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RecordExpenses");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.Order", b =>
                {
                    b.HasOne("Sales_Monitoring.SalesMonitoring.Domain.Models.OrderCollection", "OrderCollection")
                        .WithMany("orders")
                        .HasForeignKey("OrderCollectionId");

                    b.Navigation("OrderCollection");
                });

            modelBuilder.Entity("Sales_Monitoring.SalesMonitoring.Domain.Models.OrderCollection", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
