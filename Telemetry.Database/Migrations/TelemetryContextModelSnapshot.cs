﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telemetry.Database;

namespace Telemetry.Database.Migrations
{
    [DbContext(typeof(TelemetryContext))]
    partial class TelemetryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Telemetry.Database.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Telemetry.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Telemetry.Database.Models.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateTime");

                    b.Property<Guid>("ValueTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Telemetry.Database.Models.ValueType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("SensorId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasAlternateKey("SensorId", "Name");

                    b.ToTable("ValueTypes");
                });

            modelBuilder.Entity("Telemetry.Database.Models.Sensor", b =>
                {
                    b.HasOne("Telemetry.Database.Models.User", "User")
                        .WithMany("Sensors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Telemetry.Database.Models.Value", b =>
                {
                    b.HasOne("Telemetry.Database.Models.ValueType", "ValueType")
                        .WithMany("Values")
                        .HasForeignKey("ValueTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Telemetry.Database.Models.ValueType", b =>
                {
                    b.HasOne("Telemetry.Database.Models.Sensor", "Sensor")
                        .WithMany("Values")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
