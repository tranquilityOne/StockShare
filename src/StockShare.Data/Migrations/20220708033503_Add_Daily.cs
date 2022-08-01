using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class Add_Daily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SS_Daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Open = table.Column<float>(type: "float", nullable: false),
                    High = table.Column<float>(type: "float", nullable: false),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    TS_Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trade_Date = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Open = table.Column<float>(type: "float", nullable: false),
                    High = table.Column<float>(type: "float", nullable: false),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Pre_Close = table.Column<float>(type: "float", nullable: false),
                    Change = table.Column<float>(type: "float", nullable: false),
                    Percentage_Change = table.Column<float>(type: "float", nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                name: "IX_SZ_Daily_Volume",
                table: "SZ_Daily",
                column: "Volume");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SS_Daily");

            migrationBuilder.DropTable(
                name: "SZ_Daily");
        }
    }
}
