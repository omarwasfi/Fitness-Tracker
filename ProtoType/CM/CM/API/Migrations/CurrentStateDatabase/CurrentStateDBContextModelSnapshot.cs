﻿// <auto-generated />
using System;
using CM.Library.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CM.API.Migrations.CurrentStateDatabase
{
    [DbContext(typeof(CurrentStateDBContext))]
    partial class CurrentStateDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.CarBrandDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.CarDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CarBrandId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.FixRequestDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FromId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProblemId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ToId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ProblemId");

                    b.HasIndex("ToId");

                    b.ToTable("FixRequests");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.OfferFixRequestDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FromId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProblemId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ToId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ProblemId");

                    b.HasIndex("ToId");

                    b.ToTable("OfferFixRequests");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.OwnedCarDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CarId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("PersonId");

                    b.ToTable("OwnedCars");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.ProblemDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("OwnedCarId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProblemTypeId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OwnedCarId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProblemTypeId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.ProblemTypeDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProblemTypes");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.MessageContentDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PictureId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.ToTable("MessageContents");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.MessageDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FromId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MessageContentId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoomId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("MessageContentId");

                    b.HasIndex("RoomId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.RoomDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("CM.Library.DataModels.OTPDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PersonId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("OTPs");
                });

            modelBuilder.Entity("CM.Library.DataModels.PersonDataModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsAFixer")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfilePictureId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("ProfilePictureId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CM.Library.DataModels.PictureDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FileExtension")
                        .HasColumnType("longtext");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PersonDataModelRoomDataModel", b =>
                {
                    b.Property<string>("PeopleId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoomsId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("PeopleId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("PersonDataModelRoomDataModel");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.CarDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.BusinessModels.CarBrandDataModel", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId");

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.FixRequestDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("CM.Library.DataModels.BusinessModels.ProblemDataModel", "Problem")
                        .WithMany()
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Library.DataModels.PersonDataModel", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("From");

                    b.Navigation("Problem");

                    b.Navigation("To");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.OfferFixRequestDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("CM.Library.DataModels.BusinessModels.ProblemDataModel", "Problem")
                        .WithMany()
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Library.DataModels.PersonDataModel", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("From");

                    b.Navigation("Problem");

                    b.Navigation("To");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.OwnedCarDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.BusinessModels.CarDataModel", "Car")
                        .WithMany("OwnedCars")
                        .HasForeignKey("CarId");

                    b.HasOne("CM.Library.DataModels.PersonDataModel", "Person")
                        .WithMany("OwnedCars")
                        .HasForeignKey("PersonId");

                    b.Navigation("Car");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.ProblemDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.BusinessModels.OwnedCarDataModel", "OwnedCar")
                        .WithMany("Problems")
                        .HasForeignKey("OwnedCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Library.DataModels.PersonDataModel", "Person")
                        .WithMany("Problems")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Library.DataModels.BusinessModels.ProblemTypeDataModel", "ProblemType")
                        .WithMany()
                        .HasForeignKey("ProblemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnedCar");

                    b.Navigation("Person");

                    b.Navigation("ProblemType");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.MessageContentDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PictureDataModel", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.MessageDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", "From")
                        .WithMany("Messages")
                        .HasForeignKey("FromId");

                    b.HasOne("CM.Library.DataModels.Chat.MessageContentDataModel", "MessageContent")
                        .WithMany()
                        .HasForeignKey("MessageContentId");

                    b.HasOne("CM.Library.DataModels.Chat.RoomDataModel", "Room")
                        .WithMany("Messages")
                        .HasForeignKey("RoomId");

                    b.Navigation("From");

                    b.Navigation("MessageContent");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("CM.Library.DataModels.OTPDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", "Person")
                        .WithMany("OTPs")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CM.Library.DataModels.PersonDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PictureDataModel", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePictureId");

                    b.Navigation("ProfilePicture");
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
                    b.HasOne("CM.Library.DataModels.PersonDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", null)
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

                    b.HasOne("CM.Library.DataModels.PersonDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonDataModelRoomDataModel", b =>
                {
                    b.HasOne("CM.Library.DataModels.PersonDataModel", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Library.DataModels.Chat.RoomDataModel", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.CarDataModel", b =>
                {
                    b.Navigation("OwnedCars");
                });

            modelBuilder.Entity("CM.Library.DataModels.BusinessModels.OwnedCarDataModel", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("CM.Library.DataModels.Chat.RoomDataModel", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CM.Library.DataModels.PersonDataModel", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("OTPs");

                    b.Navigation("OwnedCars");

                    b.Navigation("Problems");
                });
#pragma warning restore 612, 618
        }
    }
}
