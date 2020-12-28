using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class fg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemperatureC",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "File",
                newName: "FileName");

            migrationBuilder.CreateTable(
                name: "FilesRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesRows_File_FileModelId",
                        column: x => x.FileModelId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesRows_FileModelId",
                table: "FilesRows",
                column: "FileModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesRows");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "File",
                newName: "Summary");

            migrationBuilder.AddColumn<int>(
                name: "TemperatureC",
                table: "File",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
