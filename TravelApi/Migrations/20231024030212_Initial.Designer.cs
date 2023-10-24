﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

#nullable disable

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    [Migration("20231024030212_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Landmark")
                        .HasColumnType("longtext");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");

                    b.HasData(
                        new
                        {
                            DestinationId = 1,
                            City = "Portland, Oregon",
                            Country = "United State",
                            Landmark = "Portland Sign"
                        },
                        new
                        {
                            DestinationId = 2,
                            City = "Burlington, Vermont",
                            Country = "United State",
                            Landmark = "Lake Champlain"
                        },
                        new
                        {
                            DestinationId = 3,
                            City = "Big Sur, California",
                            Country = "United State",
                            Landmark = "Big Sur"
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.HasKey("ReviewId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            DestinationId = 1,
                            Rating = 6,
                            Remarks = "It rains too much."
                        },
                        new
                        {
                            ReviewId = 2,
                            DestinationId = 2,
                            Rating = 10,
                            Remarks = "The trees are beautiful in the fall!"
                        },
                        new
                        {
                            ReviewId = 3,
                            DestinationId = 3,
                            Rating = 9,
                            Remarks = "I've never seen a better sunset."
                        },
                        new
                        {
                            ReviewId = 4,
                            DestinationId = 1,
                            Rating = 8,
                            Remarks = "Some amazing food in this city!"
                        },
                        new
                        {
                            ReviewId = 5,
                            DestinationId = 1,
                            Rating = 7,
                            Remarks = "The people don't understand sarcasm."
                        },
                        new
                        {
                            ReviewId = 6,
                            DestinationId = 2,
                            Rating = 9,
                            Remarks = "I'd raise a family here."
                        });
                });

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.HasOne("TravelApi.Models.Destination", "Destination")
                        .WithMany("Reviews")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TravelApi.Models.Destination", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
