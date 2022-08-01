﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockShare.Data;

namespace StockShare.Data.Migrations
{
    [DbContext(typeof(StockShareContext))]
    [Migration("20220708033503_Add_Daily")]
    partial class Add_Daily
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("StockShare.Data.Entities.MemberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MemberType")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MobileArea")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RealName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoginName")
                        .IsUnique();

                    b.ToTable("Member");
                });

            modelBuilder.Entity("StockShare.Data.Entities.SSDailyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<float>("Change")
                        .HasColumnType("float");

                    b.Property<float>("Close")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<float>("High")
                        .HasColumnType("float");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<float>("Low")
                        .HasColumnType("float");

                    b.Property<float>("Open")
                        .HasColumnType("float");

                    b.Property<float>("Percentage_Change")
                        .HasColumnType("float");

                    b.Property<float>("Pre_Close")
                        .HasColumnType("float");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Trade_Date")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Percentage_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.ToTable("SS_Daily");
                });

            modelBuilder.Entity("StockShare.Data.Entities.SZDailyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<float>("Change")
                        .HasColumnType("float");

                    b.Property<float>("Close")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<float>("High")
                        .HasColumnType("float");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<float>("Low")
                        .HasColumnType("float");

                    b.Property<float>("Open")
                        .HasColumnType("float");

                    b.Property<float>("Percentage_Change")
                        .HasColumnType("float");

                    b.Property<float>("Pre_Close")
                        .HasColumnType("float");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Trade_Date")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Percentage_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.ToTable("SZ_Daily");
                });

            modelBuilder.Entity("StockShare.Data.Entities.StockEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CnSpell")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Delist_Date")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EnName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IS_HS")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("List_Date")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("List_Status")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Market")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.HasIndex("TS_Code")
                        .IsUnique();

                    b.ToTable("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
