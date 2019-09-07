﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hachathon.Database;

namespace hachathon.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190907215612_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("hachathon.Domain.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("hachathon.Domain.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Phone");

                    b.HasData(
                        new
                        {
                            Id = 15,
                            Available = false,
                            Number = "114-532-9991"
                        },
                        new
                        {
                            Id = 1,
                            Available = false,
                            Number = "212-532-9991"
                        },
                        new
                        {
                            Id = 2,
                            Available = false,
                            Number = "312-532-9911"
                        },
                        new
                        {
                            Id = 3,
                            Available = false,
                            Number = "402-552-9291"
                        },
                        new
                        {
                            Id = 4,
                            Available = false,
                            Number = "502-532-9991"
                        },
                        new
                        {
                            Id = 5,
                            Available = false,
                            Number = "612-532-9991"
                        },
                        new
                        {
                            Id = 6,
                            Available = false,
                            Number = "702-532-9991"
                        },
                        new
                        {
                            Id = 7,
                            Available = false,
                            Number = "812-532-9991"
                        },
                        new
                        {
                            Id = 8,
                            Available = false,
                            Number = "912-532-9991"
                        },
                        new
                        {
                            Id = 9,
                            Available = false,
                            Number = "112-532-9991"
                        },
                        new
                        {
                            Id = 10,
                            Available = false,
                            Number = "222-532-9991"
                        },
                        new
                        {
                            Id = 11,
                            Available = false,
                            Number = "332-532-9991"
                        },
                        new
                        {
                            Id = 12,
                            Available = false,
                            Number = "442-552-9991"
                        },
                        new
                        {
                            Id = 13,
                            Available = false,
                            Number = "552-532-9191"
                        },
                        new
                        {
                            Id = 14,
                            Available = false,
                            Number = "662-555-9551"
                        });
                });

            modelBuilder.Entity("hachathon.Domain.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Plan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Plan for a every body",
                            Name = "Start Kit",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Unlimited data, calls, messages",
                            Name = "Unlimited Kit",
                            Price = 20.10m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Special service.",
                            Name = "Gold Kit",
                            Price = 40.22m
                        });
                });

            modelBuilder.Entity("hachathon.Domain.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        });
                });

            modelBuilder.Entity("hachathon.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PhoneId");

                    b.Property<int>("PlanId");

                    b.Property<int>("Score");

                    b.Property<string>("Ssn")
                        .IsRequired();

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId")
                        .IsUnique();

                    b.HasIndex("PlanId");

                    b.HasIndex("StatusId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Address = "Renton, WA",
                            Email = "example@exmaple.com",
                            LastName = "Sin",
                            Name = "John",
                            PhoneId = 1,
                            PlanId = 1,
                            Score = 312,
                            Ssn = "445223",
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("hachathon.Domain.Models.Document", b =>
                {
                    b.HasOne("hachathon.Domain.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hachathon.Domain.Models.User", b =>
                {
                    b.HasOne("hachathon.Domain.Models.Phone", "Phone")
                        .WithOne("User")
                        .HasForeignKey("hachathon.Domain.Models.User", "PhoneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hachathon.Domain.Models.Plan", "Plan")
                        .WithMany("Users")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hachathon.Domain.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
