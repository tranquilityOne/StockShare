using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEndDateYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "End_date_year",
                table: "FinanceIndicator",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: string.Empty)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_date_year",
                table: "FinanceIndicator");
        }
    }
}
