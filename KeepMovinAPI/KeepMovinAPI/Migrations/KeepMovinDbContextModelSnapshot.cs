﻿// <auto-generated />
using System;
using KeepMovinAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeepMovinAPI.Migrations
{
    [DbContext(typeof(KeepMovinDbContext))]
    partial class KeepMovinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventUser", b =>
                {
                    b.Property<Guid>("EventsEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersUserid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventsEventId", "UsersUserid");

                    b.HasIndex("UsersUserid");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("EndEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExperienceLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<Guid?>("ProfilePicturePictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Rating")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<Guid?>("SportsSportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventId");

                    b.HasIndex("ExperienceLevelId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProfilePicturePictureId");

                    b.HasIndex("SportsSportId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.EventType", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("TypeId");

                    b.ToTable("EventType");

                    b.HasData(
                        new
                        {
                            TypeId = new Guid("043d6b28-457b-4bff-9b39-bb25c40bd10c"),
                            Name = "Professional"
                        },
                        new
                        {
                            TypeId = new Guid("e5ab82b6-742f-4852-b78c-987cf8c8cf32"),
                            Name = "Recreational"
                        });
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.ExperienceLevel", b =>
                {
                    b.Property<Guid>("ExperienceLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ExperienceLevelId");

                    b.ToTable("ExperienceLevel");

                    b.HasData(
                        new
                        {
                            ExperienceLevelId = new Guid("594879d3-9d34-4366-b61c-df4fd247e280"),
                            Name = "Beginner"
                        },
                        new
                        {
                            ExperienceLevelId = new Guid("38af71e8-be10-4224-a99d-afdca4ed943f"),
                            Name = "Intermediate"
                        },
                        new
                        {
                            ExperienceLevelId = new Guid("bd24cf1f-c5d3-4f7a-a8bb-2190c09b4a94"),
                            Name = "Expert"
                        });
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            LocationId = new Guid("086f16a1-02e2-46e7-ae73-dd890cd61eb7"),
                            City = "Krakow",
                            Country = "Poland",
                            ZipCode = "30-389"
                        },
                        new
                        {
                            LocationId = new Guid("0339784e-1344-47c5-8b7a-ec1b9640a6c3"),
                            City = "Warszawa",
                            Country = "Poland",
                            ZipCode = "30-389"
                        },
                        new
                        {
                            LocationId = new Guid("7fcd6ebb-891f-41ec-8802-dbfcb019c9a9"),
                            City = "Gdansk",
                            Country = "Poland",
                            ZipCode = "30-389"
                        },
                        new
                        {
                            LocationId = new Guid("80a7caca-0887-4088-9eed-8d846d7abaae"),
                            City = "Opole",
                            Country = "Poland",
                            ZipCode = "30-389"
                        });
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Organisation", b =>
                {
                    b.Property<Guid>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IsVerify")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("OrganisationId");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Picture", b =>
                {
                    b.Property<Guid>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PicturePath")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PictureId");

                    b.HasIndex("EventId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Setting", b =>
                {
                    b.Property<Guid>("SettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AboutMe")
                        .HasColumnType("bit");

                    b.Property<bool>("FollowersFollowing")
                        .HasColumnType("bit");

                    b.Property<bool>("Location")
                        .HasColumnType("bit");

                    b.Property<bool>("Photo")
                        .HasColumnType("bit");

                    b.Property<bool>("PreviousEvents")
                        .HasColumnType("bit");

                    b.Property<bool>("Statistics")
                        .HasColumnType("bit");

                    b.Property<bool>("UpcomingEvents")
                        .HasColumnType("bit");

                    b.HasKey("SettingsId");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Sport", b =>
                {
                    b.Property<Guid>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("SportId");

                    b.ToTable("Sport");

                    b.HasData(
                        new
                        {
                            SportId = new Guid("d14f9779-1ac7-425e-8dba-1c637626ff71"),
                            Name = "Baseball"
                        },
                        new
                        {
                            SportId = new Guid("aa54c08d-a305-4e62-a27a-c32a6dd8c7f9"),
                            Name = "Football"
                        },
                        new
                        {
                            SportId = new Guid("c905946b-0429-4c39-888c-f79e1d39945d"),
                            Name = "Cycling"
                        },
                        new
                        {
                            SportId = new Guid("6a33789b-7e44-41c8-897d-5fa01b837bdb"),
                            Name = "HandBall"
                        },
                        new
                        {
                            SportId = new Guid("db69ac42-6da5-4d76-bd02-e6106a7cd795"),
                            Name = "Climbing"
                        },
                        new
                        {
                            SportId = new Guid("088c8571-6f2d-47c1-a115-f97095436064"),
                            Name = "Fishing"
                        },
                        new
                        {
                            SportId = new Guid("f389edfc-1b6d-4270-b579-4e8a391d8040"),
                            Name = "Running"
                        },
                        new
                        {
                            SportId = new Guid("28c5142f-b05d-4d4d-b712-a5da051e99b6"),
                            Name = "Volleyball"
                        },
                        new
                        {
                            SportId = new Guid("d85731cf-a4c8-44f9-a2eb-d1cc5b77bec3"),
                            Name = "Basketball"
                        },
                        new
                        {
                            SportId = new Guid("d8f36640-9cb0-4f2d-a962-347640ac847d"),
                            Name = "Nordic Walking"
                        });
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.User", b =>
                {
                    b.Property<Guid>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.UserProfile", b =>
                {
                    b.Property<Guid>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrganiserUserid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PersonalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<Guid?>("PictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserProfileId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("OrganiserUserid");

                    b.HasIndex("PictureId");

                    b.HasIndex("SettingsId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<Guid>("FollowedUserid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowersUserid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowedUserid", "FollowersUserid");

                    b.HasIndex("FollowersUserid");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.HasOne("KeepMovinAPI.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeepMovinAPI.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Event", b =>
                {
                    b.HasOne("KeepMovinAPI.Domain.ExperienceLevel", "ExperienceLevel")
                        .WithMany()
                        .HasForeignKey("ExperienceLevelId");

                    b.HasOne("KeepMovinAPI.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("KeepMovinAPI.Domain.Picture", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePicturePictureId");

                    b.HasOne("KeepMovinAPI.Domain.Sport", "Sports")
                        .WithMany()
                        .HasForeignKey("SportsSportId");

                    b.HasOne("KeepMovinAPI.Domain.EventType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("KeepMovinAPI.Domain.UserProfile", "User")
                        .WithMany()
                        .HasForeignKey("UserProfileId");

                    b.Navigation("ExperienceLevel");

                    b.Navigation("Location");

                    b.Navigation("ProfilePicture");

                    b.Navigation("Sports");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Picture", b =>
                {
                    b.HasOne("KeepMovinAPI.Domain.Event", null)
                        .WithMany("Pictures")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.UserProfile", b =>
                {
                    b.HasOne("KeepMovinAPI.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("KeepMovinAPI.Domain.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId");

                    b.HasOne("KeepMovinAPI.Domain.User", "Organiser")
                        .WithMany()
                        .HasForeignKey("OrganiserUserid");

                    b.HasOne("KeepMovinAPI.Domain.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");

                    b.HasOne("KeepMovinAPI.Domain.Setting", "Setting")
                        .WithMany()
                        .HasForeignKey("SettingsId");

                    b.Navigation("Location");

                    b.Navigation("Organisation");

                    b.Navigation("Organiser");

                    b.Navigation("Picture");

                    b.Navigation("Setting");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("KeepMovinAPI.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("FollowedUserid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeepMovinAPI.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersUserid")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeepMovinAPI.Domain.Event", b =>
                {
                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
