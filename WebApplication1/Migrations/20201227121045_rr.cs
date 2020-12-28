using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class rr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FilesRows");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "FilesRows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "FilesRows");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FilesRows",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
