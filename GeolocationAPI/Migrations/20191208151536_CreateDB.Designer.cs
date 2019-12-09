﻿// <auto-generated />
using GeolocationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeolocationAPI.Migrations
{
    [DbContext(typeof(GeolocationAPIContext))]
    [Migration("20191208151536_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeolocationAPI.Models.GeolocationData", b =>
                {
                    b.Property<string>("IP")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("ContinentCode");

                    b.Property<string>("ContinentName");

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryName");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("RegionCode");

                    b.Property<string>("RegionName");

                    b.Property<string>("Type");

                    b.Property<string>("Zip");

                    b.HasKey("IP");

                    b.ToTable("GeolocationData");
                });
#pragma warning restore 612, 618
        }
    }
}
