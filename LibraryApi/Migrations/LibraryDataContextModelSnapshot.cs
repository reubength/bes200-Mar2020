﻿// <auto-generated />
using System;
using LibraryApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApi.Migrations
{
    [DbContext(typeof(LibraryDataContext))]
    partial class LibraryDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryApi.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("InInventory")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Thoreau",
                            Genre = "Philosophy",
                            InInventory = true,
                            NumberOfPages = 322,
                            Title = "Walden"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Franz Kafka",
                            Genre = "Fiction",
                            InInventory = true,
                            NumberOfPages = 180,
                            Title = "In the Penal Colony"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Franz Kafka",
                            Genre = "Fiction",
                            InInventory = true,
                            NumberOfPages = 223,
                            Title = "The Trial"
                        });
                });

            modelBuilder.Entity("LibraryApi.Domain.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Books")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("For")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Satus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
