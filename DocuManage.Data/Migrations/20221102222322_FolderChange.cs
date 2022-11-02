using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocuManage.Data.Migrations
{
    public partial class FolderChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderDto_FolderDto_ParentId",
                table: "FolderDto");

            migrationBuilder.DropIndex(
                name: "IX_FolderDto_ParentId",
                table: "FolderDto");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "FolderDto",
                newName: "Parent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parent",
                table: "FolderDto",
                newName: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderDto_ParentId",
                table: "FolderDto",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FolderDto_FolderDto_ParentId",
                table: "FolderDto",
                column: "ParentId",
                principalTable: "FolderDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
