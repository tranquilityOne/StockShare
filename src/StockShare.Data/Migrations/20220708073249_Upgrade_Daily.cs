using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class Upgrade_Daily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SZ_Daily_TS_Code_Trade_Date",
                table: "SZ_Daily",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SS_Daily_TS_Code_Trade_Date",
                table: "SS_Daily",
                columns: new[] { "TS_Code", "Trade_Date" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SZ_Daily_TS_Code_Trade_Date",
                table: "SZ_Daily");

            migrationBuilder.DropIndex(
                name: "IX_SS_Daily_TS_Code_Trade_Date",
                table: "SS_Daily");
        }
    }
}
