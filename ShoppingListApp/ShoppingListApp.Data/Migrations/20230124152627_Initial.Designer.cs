﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingListApp.Data;

#nullable disable

namespace ShoppingListApp.Data.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    [Migration("20230124152627_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingListApp.Domain.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Shops", (string)null);
                });

            modelBuilder.Entity("ShoppingListApp.Domain.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("ShoppingListApp.Domain.ShoppingList", b =>
                {
                    b.OwnsMany("ShoppingListApp.Domain.ShoppingListItem", "Items", b1 =>
                        {
                            b1.Property<int>("ShoppingListId")
                                .HasColumnType("int");

                            b1.Property<int>("Index")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Index"), 1L, 1);

                            b1.Property<int?>("ShopId")
                                .HasColumnType("int");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ShoppingListId", "Index");

                            b1.HasIndex("ShopId");

                            b1.ToTable("ShoppingListItems", (string)null);

                            b1.HasOne("ShoppingListApp.Domain.Shop", "Shop")
                                .WithMany()
                                .HasForeignKey("ShopId");

                            b1.WithOwner("ShoppingList")
                                .HasForeignKey("ShoppingListId");

                            b1.Navigation("Shop");

                            b1.Navigation("ShoppingList");
                        });

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
