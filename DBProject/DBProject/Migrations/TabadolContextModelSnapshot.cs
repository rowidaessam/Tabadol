﻿// <auto-generated />
using System;
using DBProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBProject.Migrations
{
    [DbContext(typeof(TabadolContext))]
    partial class TabadolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DBProject.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.HasIndex("SSN");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("DBProject.Models.AdminAssociation", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("ASSId")
                        .HasColumnType("int");

                    b.HasKey("AdminId", "ASSId");

                    b.HasIndex("ASSId");

                    b.ToTable("AdminAssociation");
                });

            modelBuilder.Entity("DBProject.Models.AdminCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "AdminId");

                    b.HasIndex("AdminId");

                    b.ToTable("AdminCategory");
                });

            modelBuilder.Entity("DBProject.Models.Association", b =>
                {
                    b.Property<int>("ASSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ASSId"), 1L, 1);

                    b.Property<string>("ASSAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ASSName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ASSId");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("DBProject.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"), 1L, 1);

                    b.Property<int>("NumberOfProducts")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("DBProject.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DBProject.Models.Feedback", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("GaveFeedback")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TookFeedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "GaveFeedback");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("DBProject.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("Freight")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DBProject.Models.OrderDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "Quantity");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DBProject.Models.PersonalInformation", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("DBProject.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityPerUnit")
                        .HasColumnType("int");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DBProject.Models.ProductAssociation", b =>
                {
                    b.Property<int>("ASSId")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ASSId", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductAssociation");
                });

            modelBuilder.Entity("DBProject.Models.ProductUser", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductUser");
                });

            modelBuilder.Entity("DBProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("NumberOfExchanges")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("SSN");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DBProject.Models.UserAssociation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ASSId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ASSId");

                    b.HasIndex("ASSId");

                    b.ToTable("UserAssociation");
                });

            modelBuilder.Entity("DBProject.Models.Admin", b =>
                {
                    b.HasOne("DBProject.Models.PersonalInformation", "PersonalInformation")
                        .WithMany()
                        .HasForeignKey("SSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("DBProject.Models.AdminAssociation", b =>
                {
                    b.HasOne("DBProject.Models.Association", "Association")
                        .WithMany("AdminAssociations")
                        .HasForeignKey("ASSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.Admin", "Admin")
                        .WithMany("AdminAssociations")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Association");
                });

            modelBuilder.Entity("DBProject.Models.AdminCategory", b =>
                {
                    b.HasOne("DBProject.Models.Admin", "Admin")
                        .WithMany("AdminCategories")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.Category", "Category")
                        .WithMany("AdminCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DBProject.Models.Card", b =>
                {
                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.Feedback", b =>
                {
                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.Order", b =>
                {
                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.OrderDetail", b =>
                {
                    b.HasOne("DBProject.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DBProject.Models.Product", b =>
                {
                    b.HasOne("DBProject.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.ProductAssociation", b =>
                {
                    b.HasOne("DBProject.Models.Association", "Association")
                        .WithMany("ProductAssociations")
                        .HasForeignKey("ASSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.Product", "Product")
                        .WithMany("ProductAssociations")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Association");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DBProject.Models.ProductUser", b =>
                {
                    b.HasOne("DBProject.Models.Product", "Product")
                        .WithMany("ProductUsers")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany("ProductUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.User", b =>
                {
                    b.HasOne("DBProject.Models.PersonalInformation", "PersonalInformation")
                        .WithMany()
                        .HasForeignKey("SSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("DBProject.Models.UserAssociation", b =>
                {
                    b.HasOne("DBProject.Models.Association", "Association")
                        .WithMany("UserAssociations")
                        .HasForeignKey("ASSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBProject.Models.User", "User")
                        .WithMany("UserAssociations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Association");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBProject.Models.Admin", b =>
                {
                    b.Navigation("AdminAssociations");

                    b.Navigation("AdminCategories");
                });

            modelBuilder.Entity("DBProject.Models.Association", b =>
                {
                    b.Navigation("AdminAssociations");

                    b.Navigation("ProductAssociations");

                    b.Navigation("UserAssociations");
                });

            modelBuilder.Entity("DBProject.Models.Category", b =>
                {
                    b.Navigation("AdminCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DBProject.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("DBProject.Models.Product", b =>
                {
                    b.Navigation("ProductAssociations");

                    b.Navigation("ProductUsers");
                });

            modelBuilder.Entity("DBProject.Models.User", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");

                    b.Navigation("ProductUsers");

                    b.Navigation("Products");

                    b.Navigation("UserAssociations");
                });
#pragma warning restore 612, 618
        }
    }
}