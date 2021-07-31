using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreAppPostgreSQL.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descirption",
                table: "Security");

            migrationBuilder.RenameColumn(
                name: "SecurityID",
                table: "Security",
                newName: "SecurityId");

            migrationBuilder.RenameColumn(
                name: "ISIN",
                table: "Security",
                newName: "DealID");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityId",
                table: "Security",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Security",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Security",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Security",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Security");

            migrationBuilder.RenameColumn(
                name: "SecurityId",
                table: "Security",
                newName: "SecurityID");

            migrationBuilder.RenameColumn(
                name: "DealID",
                table: "Security",
                newName: "ISIN");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityID",
                table: "Security",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Security",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Security",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Descirption",
                table: "Security",
                nullable: false,
                defaultValue: "");
        }
    }
}
