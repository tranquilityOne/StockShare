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
    [Migration("20221123061633_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("StockShare.Data.Entities.Daily_BJS_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Adj_Factor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Circ_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("DV_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DV_Ratio_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Down_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Float_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Free_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Pct_Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Total_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Trade_Date")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("TurnOver_Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TurnOver_Rate_Float")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Up_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Pct_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.HasIndex("TS_Code", "Trade_Date")
                        .IsUnique();

                    b.ToTable("Daily_BJS");
                });

            modelBuilder.Entity("StockShare.Data.Entities.Daily_CYB_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Adj_Factor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Circ_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("DV_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DV_Ratio_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Down_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Float_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Free_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Pct_Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Total_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Trade_Date")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("TurnOver_Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TurnOver_Rate_Float")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Up_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Pct_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.HasIndex("TS_Code", "Trade_Date")
                        .IsUnique();

                    b.ToTable("Daily_CYB");
                });

            modelBuilder.Entity("StockShare.Data.Entities.Daily_KCB_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Adj_Factor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Circ_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("DV_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DV_Ratio_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Down_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Float_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Free_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Pct_Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Total_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Trade_Date")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("TurnOver_Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TurnOver_Rate_Float")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Up_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Pct_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.HasIndex("TS_Code", "Trade_Date")
                        .IsUnique();

                    b.ToTable("Daily_KCB");
                });

            modelBuilder.Entity("StockShare.Data.Entities.Daily_ZB_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Adj_Factor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Circ_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("DV_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DV_Ratio_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Down_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Float_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Free_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Pct_Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Total_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Trade_Date")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("TurnOver_Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TurnOver_Rate_Float")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Up_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Pct_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.HasIndex("TS_Code", "Trade_Date")
                        .IsUnique();

                    b.ToTable("Daily_ZB");
                });

            modelBuilder.Entity("StockShare.Data.Entities.Daily_ZXB_Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Adj_Factor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Circ_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Close_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("DV_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("DV_Ratio_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Down_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Float_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Free_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("High_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Low_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_HFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Open_QFQ")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PE_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PS_TTM")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Pct_Change")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TS_Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Total_MV")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Share")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Trade_Date")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("TurnOver_Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TurnOver_Rate_Float")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Up_Limit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume_Ratio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("Amount");

                    b.HasIndex("Pct_Change");

                    b.HasIndex("TS_Code");

                    b.HasIndex("Trade_Date");

                    b.HasIndex("Volume");

                    b.HasIndex("TS_Code", "Trade_Date")
                        .IsUnique();

                    b.ToTable("Daily_ZXB");
                });

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

            modelBuilder.Entity("StockShare.Data.Entities.StatsRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<int>("EndTradeDate")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("LatestUpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<int>("StartTradeDate")
                        .HasColumnType("int");

                    b.Property<int>("StatsRecordType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StatsRecord");
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
