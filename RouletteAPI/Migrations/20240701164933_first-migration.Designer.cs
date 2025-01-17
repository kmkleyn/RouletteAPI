﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RouletteAPI.Data;

#nullable disable

namespace RouletteAPI.Migrations
{
    [DbContext(typeof(RouletteAPIContext))]
    [Migration("20240701164933_first-migration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("RouletteAPI.Models.Bet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("BetAmount")
                        .HasColumnType("REAL");

                    b.Property<double>("BetPayout")
                        .HasColumnType("REAL");

                    b.Property<int>("BetTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChosenNumbers")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatePlaced")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoundId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("RouletteAPI.Models.BetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BetRate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumbersInBet")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BetType");
                });

            modelBuilder.Entity("RouletteAPI.Models.Round", b =>
                {
                    b.Property<Guid>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RoundCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("WinningNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoundId");

                    b.ToTable("Round");
                });
#pragma warning restore 612, 618
        }
    }
}
