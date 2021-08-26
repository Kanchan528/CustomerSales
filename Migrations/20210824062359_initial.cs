using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSales.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNmber",
                table: "ECustomers",
                newName: "ContactNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "ECustomers",
                newName: "ContactNmber");
        }
    }
}
