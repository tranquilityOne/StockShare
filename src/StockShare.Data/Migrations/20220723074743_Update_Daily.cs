using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class Update_Daily : Migration
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
                    table.PrimaryKey("PK_Daily_BJS", x => x.Id);
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
                    table.PrimaryKey("PK_Daily_KCB", x => x.Id);
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
                    table.PrimaryKey("PK_Daily_ZXB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Amount",
                table: "Daily_BJS",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_BJS_Percentage_Change",
                table: "Daily_BJS",
                column: "Percentage_Change");

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
                name: "IX_Daily_KCB_Amount",
                table: "Daily_KCB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_KCB_Percentage_Change",
                table: "Daily_KCB",
                column: "Percentage_Change");

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
                name: "IX_Daily_ZXB_Amount",
                table: "Daily_ZXB",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_ZXB_Percentage_Change",
                table: "Daily_ZXB",
                column: "Percentage_Change");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily_BJS");

            migrationBuilder.DropTable(
                name: "Daily_KCB");

            migrationBuilder.DropTable(
                name: "Daily_ZXB");
        }
    }
}
