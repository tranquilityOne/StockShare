using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShare.Data.Migrations
{
    public partial class Upgrade_Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ts_code",
                table: "Stock",
                newName: "TS_Code");

            migrationBuilder.RenameColumn(
                name: "symbol",
                table: "Stock",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stock",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "market",
                table: "Stock",
                newName: "Market");

            migrationBuilder.RenameColumn(
                name: "list_date",
                table: "Stock",
                newName: "List_Date");

            migrationBuilder.RenameColumn(
                name: "list_Status",
                table: "Stock",
                newName: "List_Status");

            migrationBuilder.RenameColumn(
                name: "is_hs",
                table: "Stock",
                newName: "IS_HS");

            migrationBuilder.RenameColumn(
                name: "industry",
                table: "Stock",
                newName: "Industry");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Stock",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "enname",
                table: "Stock",
                newName: "EnName");

            migrationBuilder.RenameColumn(
                name: "delist_date",
                table: "Stock",
                newName: "Delist_Date");

            migrationBuilder.RenameColumn(
                name: "cnspell",
                table: "Stock",
                newName: "CnSpell");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "Stock",
                newName: "Area");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_ts_code",
                table: "Stock",
                newName: "IX_Stock_TS_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_symbol",
                table: "Stock",
                newName: "IX_Stock_Symbol");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_name",
                table: "Stock",
                newName: "IX_Stock_Name");

            migrationBuilder.AlterColumn<string>(
                name: "TS_Code",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Market",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "List_Date",
                table: "Stock",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "List_Status",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IS_HS",
                table: "Stock",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Industry",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnName",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Delist_Date",
                table: "Stock",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CnSpell",
                table: "Stock",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Stock",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TS_Code",
                table: "Stock",
                newName: "ts_code");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Stock",
                newName: "symbol");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stock",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Market",
                table: "Stock",
                newName: "market");

            migrationBuilder.RenameColumn(
                name: "List_Status",
                table: "Stock",
                newName: "list_Status");

            migrationBuilder.RenameColumn(
                name: "List_Date",
                table: "Stock",
                newName: "list_date");

            migrationBuilder.RenameColumn(
                name: "Industry",
                table: "Stock",
                newName: "industry");

            migrationBuilder.RenameColumn(
                name: "IS_HS",
                table: "Stock",
                newName: "is_hs");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Stock",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "Stock",
                newName: "enname");

            migrationBuilder.RenameColumn(
                name: "Delist_Date",
                table: "Stock",
                newName: "delist_date");

            migrationBuilder.RenameColumn(
                name: "CnSpell",
                table: "Stock",
                newName: "cnspell");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Stock",
                newName: "area");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_TS_Code",
                table: "Stock",
                newName: "IX_Stock_ts_code");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_Symbol",
                table: "Stock",
                newName: "IX_Stock_symbol");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_Name",
                table: "Stock",
                newName: "IX_Stock_name");

            migrationBuilder.AlterColumn<string>(
                name: "ts_code",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "symbol",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "market",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "list_Status",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "list_date",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "industry",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "is_hs",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "enname",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "delist_date",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cnspell",
                table: "Stock",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "area",
                table: "Stock",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
