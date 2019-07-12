﻿// <auto-generated />
using System;
using HM.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HM.Data.Migrations
{
    [DbContext(typeof(HangmanDbContext))]
    [Migration("20190712132015_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview6.19304.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HM.Data.Entities.GameItems.GameTracker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("GameTrackers");
                });

            modelBuilder.Entity("HM.Data.Entities.GameItems.Word", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameTrackerID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("GameTrackerID");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("HM.Data.Entities.GameItems.Word", b =>
                {
                    b.HasOne("HM.Data.Entities.GameItems.GameTracker", null)
                        .WithMany("Words")
                        .HasForeignKey("GameTrackerID");
                });
#pragma warning restore 612, 618
        }
    }
}