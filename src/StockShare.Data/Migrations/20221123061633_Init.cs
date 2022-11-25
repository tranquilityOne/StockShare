using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daily_BJS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TS_Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adj_Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Up_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Down_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pct_Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate_Float = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PB = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Float_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Free_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Circ_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_BJS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Daily_CYB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TS_Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adj_Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Up_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Down_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pct_Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate_Float = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PB = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Float_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Free_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Circ_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_CYB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Daily_KCB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TS_Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adj_Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Up_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Down_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pct_Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate_Float = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PB = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Float_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Free_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Circ_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_KCB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Daily_ZB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TS_Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adj_Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Up_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Down_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pct_Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate_Float = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PB = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Float_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Free_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Circ_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_ZB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Daily_ZXB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TS_Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adj_Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Open_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    High_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Low_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_QFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Close_HFQ = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Up_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Down_Limit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pct_Change = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TurnOver_Rate_Float = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Volume_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PE_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PB = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PS_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DV_Ratio_TTM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Float_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Free_Share = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Circ_MV = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_ZXB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileArea = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatsRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTradeDate = table.Column<int>(type: "int", nullable: false),
                    EndTradeDate = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    StatsRecordType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsRecord", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TS_Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CnSpell = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    List_Status = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    List_Date = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Delist_Date = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    IS_HS = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Amount",
                table: "Daily_BJS",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Pct_Change",
                table: "Daily_BJS",
                column: "Pct_Change");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Trade_Date",
                table: "Daily_BJS",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_TS_Code",
                table: "Daily_BJS",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_TS_Code_Trade_Date",
                table: "Daily_BJS",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Volume",
                table: "Daily_BJS",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Amount",
                table: "Daily_CYB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Pct_Change",
                table: "Daily_CYB",
                column: "Pct_Change");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Trade_Date",
                table: "Daily_CYB",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_TS_Code",
                table: "Daily_CYB",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_TS_Code_Trade_Date",
                table: "Daily_CYB",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Volume",
                table: "Daily_CYB",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_Amount",
                table: "Daily_KCB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_Pct_Change",
                table: "Daily_KCB",
                column: "Pct_Change");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_Trade_Date",
                table: "Daily_KCB",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_TS_Code",
                table: "Daily_KCB",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_TS_Code_Trade_Date",
                table: "Daily_KCB",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_Volume",
                table: "Daily_KCB",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_Amount",
                table: "Daily_ZB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_Pct_Change",
                table: "Daily_ZB",
                column: "Pct_Change");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_Trade_Date",
                table: "Daily_ZB",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_TS_Code",
                table: "Daily_ZB",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_TS_Code_Trade_Date",
                table: "Daily_ZB",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_Volume",
                table: "Daily_ZB",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_Amount",
                table: "Daily_ZXB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_Pct_Change",
                table: "Daily_ZXB",
                column: "Pct_Change");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_Trade_Date",
                table: "Daily_ZXB",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_TS_Code",
                table: "Daily_ZXB",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_TS_Code_Trade_Date",
                table: "Daily_ZXB",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_Volume",
                table: "Daily_ZXB",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_Member_LoginName",
                table: "Member",
                column: "LoginName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Symbol",
                table: "Stock",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_TS_Code",
                table: "Stock",
                column: "TS_Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily_BJS");

            migrationBuilder.DropTable(
                name: "Daily_CYB");

            migrationBuilder.DropTable(
                name: "Daily_KCB");

            migrationBuilder.DropTable(
                name: "Daily_ZB");

            migrationBuilder.DropTable(
                name: "Daily_ZXB");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "StatsRecord");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
