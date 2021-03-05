﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20210228071548_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvailableTickets")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DestinationLocation")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("FlightAmount")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("FlightDate")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("SourceLocation")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("FlightId");

                    b.ToTable("tblFlight", "dbo");
                });

            modelBuilder.Entity("DAL.Entities.Flight_Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DateOfJourney")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("BookId");

                    b.HasIndex("FlightId");

                    b.ToTable("tblFlightBook", "dbo");
                });

            modelBuilder.Entity("DAL.Entities.Flight_Book", b =>
                {
                    b.HasOne("DAL.Entities.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
