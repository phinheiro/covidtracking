﻿// <auto-generated />
using System;
using BoxTI.Challenge.CovidTracking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoxTI.Challenge.CovidTracking.Data.Migrations
{
    [DbContext(typeof(CTContext))]
    [Migration("20210504193817_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.Domain.Entities.Cases", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ActiveCases")
                        .HasColumnType("int(11)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewCases")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NewDeaths")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TotalCases")
                        .HasColumnType("int(11)");

                    b.Property<int>("TotalDeaths")
                        .HasColumnType("int(11)");

                    b.Property<int>("TotalRecovered")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
