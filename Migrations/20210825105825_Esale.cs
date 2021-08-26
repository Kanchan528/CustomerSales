using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSales.Migrations
{
    public partial class Esale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ESalesDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ESales",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ESalesDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ESalesDetails");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ESalesDetails",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ESales",
                newName: "isDeleted");
        }
    }
}
