using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFinanceIndicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TsCode = table.Column<string>(name: "Ts_Code", type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Anndate = table.Column<string>(name: "Ann_date", type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enddate = table.Column<string>(name: "End_date", type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extraitem = table.Column<decimal>(name: "Extra_item", type: "decimal(65,30)", nullable: false),
                    Profitdedt = table.Column<decimal>(name: "Profit_dedt", type: "decimal(65,30)", nullable: false),
                    Grossmargin = table.Column<decimal>(name: "Gross_margin", type: "decimal(65,30)", nullable: false),
                    Opincome = table.Column<decimal>(name: "Op_income", type: "decimal(65,30)", nullable: false),
                    Valuechangeincome = table.Column<decimal>(name: "Valuechange_income", type: "decimal(65,30)", nullable: false),
                    Interstincome = table.Column<decimal>(name: "Interst_income", type: "decimal(65,30)", nullable: false),
                    Daa = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Ebit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EbitDa = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fcff = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Currentexint = table.Column<decimal>(name: "Current_exint", type: "decimal(65,30)", nullable: false),
                    Noncurrentexint = table.Column<decimal>(name: "Noncurrent_exint", type: "decimal(65,30)", nullable: false),
                    Interestdebt = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Netdebt = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Tangibleasset = table.Column<decimal>(name: "Tangible_asset", type: "decimal(65,30)", nullable: false),
                    Investcapital = table.Column<decimal>(name: "Invest_capital", type: "decimal(65,30)", nullable: false),
                    Retainedearnings = table.Column<decimal>(name: "Retained_earnings", type: "decimal(65,30)", nullable: false),
                    Bps = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Netprofitmargin = table.Column<decimal>(name: "Netprofit_margin", type: "decimal(65,30)", nullable: false),
                    Grossprofitmargin = table.Column<decimal>(name: "Grossprofit_margin", type: "decimal(65,30)", nullable: false),
                    Cogsofsales = table.Column<decimal>(name: "Cogs_of_sales", type: "decimal(65,30)", nullable: false),
                    Expenseofsales = table.Column<decimal>(name: "Expense_of_sales", type: "decimal(65,30)", nullable: false),
                    Roe = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Roewaa = table.Column<decimal>(name: "Roe_waa", type: "decimal(65,30)", nullable: false),
                    Roedt = table.Column<decimal>(name: "Roe_dt", type: "decimal(65,30)", nullable: false),
                    Roeyearly = table.Column<decimal>(name: "Roe_yearly", type: "decimal(65,30)", nullable: false),
                    Debttoassets = table.Column<decimal>(name: "Debt_to_assets", type: "decimal(65,30)", nullable: false),
                    Rdexp = table.Column<decimal>(name: "Rd_exp", type: "decimal(65,30)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LatestUpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceIndicator", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceIndicator_Roe",
                table: "FinanceIndicator",
                column: "Roe");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceIndicator_Ts_Code_End_date",
                table: "FinanceIndicator",
                columns: new[] { "Ts_Code", "End_date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceIndicator");
        }
    }
}
