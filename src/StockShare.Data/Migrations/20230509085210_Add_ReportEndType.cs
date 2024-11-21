using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReportEndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "End_type",
                table: "FinanceIndicator",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_type",
                table: "FinanceIndicator");
        }
    }
}
