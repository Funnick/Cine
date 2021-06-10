﻿// <auto-generated />
using System;
using Cine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cine.Migrations
{
    [DbContext(typeof(CineDbContext))]
    [Migration("20210609133545_CountryDelete")]
    partial class CountryDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Cine.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CinemaId");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER")
                        .HasColumnName("NumberOfSeats");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinema");
                });

            modelBuilder.Entity("Cine.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("DiscountId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<decimal>("Percent")
                        .HasColumnType("TEXT")
                        .HasColumnName("Percent");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Cine.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MovieId");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Category");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Country");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("TEXT")
                        .HasColumnName("Duration");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Genre");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("Synopsis");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("Title");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Year");

                    b.HasKey("MovieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Cine.Models.Producer", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Age");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Country");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Producer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Producer");
                });

            modelBuilder.Entity("Cine.Models.Show", b =>
                {
                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("StartTime");

                    b.Property<int>("CinemaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("Date");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("EndTime");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StartTime");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("Cine.Models.TheaterMember", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Points");

                    b.Property<string>("TheaterUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.HasIndex("TheaterUserId")
                        .IsUnique();

                    b.ToTable("TheaterMember");
                });

            modelBuilder.Entity("Cine.Models.TheaterUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Card")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Card");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Cine.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("TicketId");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT")
                        .HasColumnName("Price");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShowStartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("TheaterUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketId");

                    b.HasIndex("ShowStartTime");

                    b.HasIndex("TheaterUserId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("DiscountShow", b =>
                {
                    b.Property<int>("DiscountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShowsStartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("DiscountId", "ShowsStartTime");

                    b.HasIndex("ShowsStartTime");

                    b.ToTable("DiscountShow");
                });

            modelBuilder.Entity("DiscountTicket", b =>
                {
                    b.Property<int>("DiscountsDiscountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TicketsTicketId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DiscountsDiscountId", "TicketsTicketId");

                    b.HasIndex("TicketsTicketId");

                    b.ToTable("DiscountTicket");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Cine.Models.Actor", b =>
                {
                    b.HasBaseType("Cine.Models.Producer");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Actor_MovieId");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("MovieId");

                    b.ToTable("Producer");

                    b.HasDiscriminator().HasValue("Actor");
                });

            modelBuilder.Entity("Cine.Models.Director", b =>
                {
                    b.HasBaseType("Cine.Models.Producer");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MovieId");

                    b.ToTable("Producer");

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("Cine.Models.Show", b =>
                {
                    b.HasOne("Cine.Models.Cinema", "Cinema")
                        .WithMany("Shows")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Cine.Models.TheaterMember", b =>
                {
                    b.HasOne("Cine.Models.TheaterUser", "TheaterUser")
                        .WithOne("TheaterMember")
                        .HasForeignKey("Cine.Models.TheaterMember", "TheaterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheaterUser");
                });

            modelBuilder.Entity("Cine.Models.Ticket", b =>
                {
                    b.HasOne("Cine.Models.Show", "Show")
                        .WithMany("Ticekts")
                        .HasForeignKey("ShowStartTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Models.TheaterUser", "TheaterUser")
                        .WithMany("Ticekts")
                        .HasForeignKey("TheaterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");

                    b.Navigation("TheaterUser");
                });

            modelBuilder.Entity("DiscountShow", b =>
                {
                    b.HasOne("Cine.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Models.Show", null)
                        .WithMany()
                        .HasForeignKey("ShowsStartTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscountTicket", b =>
                {
                    b.HasOne("Cine.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountsDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsTicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Cine.Models.TheaterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Cine.Models.TheaterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Models.TheaterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Cine.Models.TheaterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cine.Models.Actor", b =>
                {
                    b.HasOne("Cine.Models.Movie", null)
                        .WithMany("Actors")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Cine.Models.Director", b =>
                {
                    b.HasOne("Cine.Models.Movie", null)
                        .WithMany("Directors")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Cine.Models.Cinema", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Cine.Models.Movie", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Directors");
                });

            modelBuilder.Entity("Cine.Models.Show", b =>
                {
                    b.Navigation("Ticekts");
                });

            modelBuilder.Entity("Cine.Models.TheaterUser", b =>
                {
                    b.Navigation("TheaterMember");

                    b.Navigation("Ticekts");
                });
#pragma warning restore 612, 618
        }
    }
}
