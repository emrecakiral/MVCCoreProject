using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCoreProject.Migrations
{
    public partial class AdressColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserAddress");
        }
    }
}
