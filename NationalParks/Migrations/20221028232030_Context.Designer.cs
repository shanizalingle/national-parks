// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NationalParks.Models;

namespace NationalParks.Migrations
{
    [DbContext(typeof(NationalParksContext))]
    [Migration("20221028232030_Context")]
    partial class Context
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NationalParks.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Cost = 35,
                            Country = "USA",
                            Name = "Glacier National Park",
                            State = "Montana"
                        },
                        new
                        {
                            ParkId = 2,
                            Cost = 35,
                            Country = "USA",
                            Name = "Yosemite National Park",
                            State = "California"
                        },
                        new
                        {
                            ParkId = 3,
                            Cost = 35,
                            Country = "USA",
                            Name = "Grand Canyon National Park",
                            State = "Arizona"
                        },
                        new
                        {
                            ParkId = 4,
                            Cost = 20,
                            Country = "USA",
                            Name = "Yellowstone National Park",
                            State = "Wyoming"
                        },
                        new
                        {
                            ParkId = 5,
                            Cost = 10,
                            Country = "Canada",
                            Name = "Jasper National Park",
                            State = "Alberta"
                        });
                });

            modelBuilder.Entity("NationalParks.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ServiceId");

                    b.HasIndex("ParkId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Cost = 100,
                            Description = "Multiple lodges to choose from",
                            Name = "Glacier National Park Lodges",
                            ParkId = 1,
                            Type = "Lodging"
                        },
                        new
                        {
                            ServiceId = 2,
                            Cost = 80,
                            Description = "Boat, bus, raft and horseback tours available",
                            Name = "Guided Tours",
                            ParkId = 1,
                            Type = "Tours"
                        },
                        new
                        {
                            ServiceId = 3,
                            Cost = 40,
                            Description = "First come first serve, with overnight parking ",
                            Name = "Wilderness Camping",
                            ParkId = 1,
                            Type = "Camping"
                        },
                        new
                        {
                            ServiceId = 4,
                            Cost = 120,
                            Description = "Tent cabins at  High Sierra Camps / deluxe rooms at The Ahwahnee",
                            Name = "Yosemite Lodging",
                            ParkId = 2,
                            Type = "Lodging"
                        },
                        new
                        {
                            ServiceId = 5,
                            Cost = 40,
                            Description = "Ranger-led programs may be available on a limited basis",
                            Name = "Ranger & Interpretive Programs",
                            ParkId = 2,
                            Type = "Program"
                        },
                        new
                        {
                            ServiceId = 6,
                            Cost = 90,
                            Description = "South Rim lodging is available all year",
                            Name = "South Rim Lodgine",
                            ParkId = 3,
                            Type = "Lodging"
                        },
                        new
                        {
                            ServiceId = 7,
                            Cost = 0,
                            Description = "23 mile scenic road between Desert View and Grand Canyon Village,",
                            Name = "Desert View",
                            ParkId = 3,
                            Type = "Scenery"
                        },
                        new
                        {
                            ServiceId = 8,
                            Cost = 0,
                            Description = "coffee bar, grab-and-go breakfast and Lunch, and hiker/biker supplies",
                            Name = "Grand Canyon Vistor Center",
                            ParkId = 3,
                            Type = "Amenities"
                        },
                        new
                        {
                            ServiceId = 9,
                            Cost = 30,
                            Description = "12 campgrounds with over 2,000 established campsites.",
                            Name = "Yosemite Campgrounds",
                            ParkId = 4,
                            Type = "Camping"
                        },
                        new
                        {
                            ServiceId = 10,
                            Cost = 0,
                            Description = "Hottest hot springs in the Canadian Rockies",
                            Name = "Miette Hot Springs",
                            ParkId = 5,
                            Type = "Scenery"
                        },
                        new
                        {
                            ServiceId = 11,
                            Cost = 140,
                            Description = "See elk, deer, bear, moose and mountain goats ",
                            Name = "Wildlife Tours",
                            ParkId = 5,
                            Type = "Tours"
                        });
                });

            modelBuilder.Entity("NationalParks.Models.Service", b =>
                {
                    b.HasOne("NationalParks.Models.Park", "Park")
                        .WithMany("Services")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Park");
                });

            modelBuilder.Entity("NationalParks.Models.Park", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
