using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SS_Daily");

            migrationBuilder.DropTable(
                name: "SZ_Daily");

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
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Open = table.Column<float>(type: "float", nullable: false),
                    High = table.Column<float>(type: "float", nullable: false),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_CYB", x => x.Id);
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
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Open = table.Column<float>(type: "float", nullable: false),
                    High = table.Column<float>(type: "float", nullable: false),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_ZB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuotesStatsRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTradeDate = table.Column<int>(type: "int", nullable: false),
                    EndTradeDate = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    QuotesStatsType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotesStatsRecord", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Amount",
                table: "Daily_CYB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_CYB_Percentage_Change",
                table: "Daily_CYB",
                column: "Percentage_Change");

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
                name: "IX_Daily_ZB_Amount",
                table: "Daily_ZB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZB_Percentage_Change",
                table: "Daily_ZB",
                column: "Percentage_Change");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily_CYB");

            migrationBuilder.DropTable(
                name: "Daily_ZB");

            migrationBuilder.DropTable(
                name: "QuotesStatsRecord");

            migrationBuilder.CreateTable(
                name: "SS_Daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    High = table.Column<float>(type: "float", nullable: false),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Open = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_Daily", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SZ_Daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    High = table.Column<float>(type: "float", nullable: false),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Open = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SZ_Daily", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_Amount",
                table: "SS_Daily",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_Percentage_Change",
                table: "SS_Daily",
                column: "Percentage_Change");

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_Trade_Date",
                table: "SS_Daily",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_TS_Code",
                table: "SS_Daily",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_TS_Code_Trade_Date",
                table: "SS_Daily",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_Volume",
                table: "SS_Daily",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_Amount",
                table: "SZ_Daily",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_Percentage_Change",
                table: "SZ_Daily",
                column: "Percentage_Change");

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_Trade_Date",
                table: "SZ_Daily",
                column: "Trade_Date");

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_TS_Code",
                table: "SZ_Daily",
                column: "TS_Code");

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_TS_Code_Trade_Date",
                table: "SZ_Daily",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_Volume",
                table: "SZ_Daily",
                column: "Volume");
        }
    }
}
