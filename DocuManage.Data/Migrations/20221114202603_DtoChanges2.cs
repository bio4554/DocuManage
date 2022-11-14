using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocuManage.Data.Migrations
{
    /// <inheritdoc />
    public partial class DtoChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDto_FolderDto_FolderId",
                table: "DocumentDto");

            migrationBuilder.DropIndex(
                name: "IX_DocumentDto_FolderId",
                table: "DocumentDto");

            migrationBuilder.RenameColumn(
                name: "FolderId",
                table: "DocumentDto",
                newName: "Folder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Folder",
                table: "DocumentDto",
                newName: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDto_FolderId",
                table: "DocumentDto",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDto_FolderDto_FolderId",
                table: "DocumentDto",
                column: "FolderId",
                principalTable: "FolderDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
