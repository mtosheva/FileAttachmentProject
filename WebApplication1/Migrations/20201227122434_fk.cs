using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesRows_File_FileModelId",
                table: "FilesRows");

            migrationBuilder.DropIndex(
                name: "IX_FilesRows_FileModelId",
                table: "FilesRows");

            migrationBuilder.DropColumn(
                name: "FileModelId",
                table: "FilesRows");

            migrationBuilder.AddColumn<int>(
                name: "FileFK",
                table: "FilesRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FilesRows_FileFK",
                table: "FilesRows",
                column: "FileFK");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesRows_File_FileFK",
                table: "FilesRows",
                column: "FileFK",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesRows_File_FileFK",
                table: "FilesRows");

            migrationBuilder.DropIndex(
                name: "IX_FilesRows_FileFK",
                table: "FilesRows");

            migrationBuilder.DropColumn(
                name: "FileFK",
                table: "FilesRows");

            migrationBuilder.AddColumn<int>(
                name: "FileModelId",
                table: "FilesRows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilesRows_FileModelId",
                table: "FilesRows",
                column: "FileModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesRows_File_FileModelId",
                table: "FilesRows",
                column: "FileModelId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
