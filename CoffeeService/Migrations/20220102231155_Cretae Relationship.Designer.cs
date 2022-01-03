﻿// <auto-generated />
using System;
using CoffeeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeService.Migrations
{
    [DbContext(typeof(CoffeeDBContext))]
    [Migration("20220102231155_Cretae Relationship")]
    partial class CretaeRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeService.Entities.Coffee", b =>
                {
                    b.Property<Guid>("CoffeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoffeeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CoffeeId");

                    b.HasIndex("CoffeeTypeId");

                    b.ToTable("Coffees", "Pdb");
                });

            modelBuilder.Entity("CoffeeService.Entities.CoffeeStore", b =>
                {
                    b.Property<Guid>("CoffeeStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoffeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Poststatus")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RecievedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoffeeStoreId");

                    b.HasIndex("CoffeeId");

                    b.ToTable("CoffeeStores", "Str");
                });

            modelBuilder.Entity("CoffeeService.Entities.CoffeeType", b =>
                {
                    b.Property<Guid>("CoffeeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityInPack")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CoffeeTypeId");

                    b.ToTable("CoffeeTypes", "Pdb");
                });

            modelBuilder.Entity("CoffeeService.Entities.Coffee", b =>
                {
                    b.HasOne("CoffeeService.Entities.CoffeeType", "CoffeeType")
                        .WithMany()
                        .HasForeignKey("CoffeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeType");
                });

            modelBuilder.Entity("CoffeeService.Entities.CoffeeStore", b =>
                {
                    b.HasOne("CoffeeService.Entities.Coffee", "Coffee")
                        .WithMany("CoffeeStores")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("CoffeeService.Entities.Coffee", b =>
                {
                    b.Navigation("CoffeeStores");
                });
#pragma warning restore 612, 618
        }
    }
}
