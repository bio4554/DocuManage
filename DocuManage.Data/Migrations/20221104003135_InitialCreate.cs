using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocuManage.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolderDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Parent = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FolderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDto_FolderDto_FolderId",
                        column: x => x.FolderId,
                        principalTable: "FolderDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDto_FolderId",
                table: "DocumentDto",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDto");

            migrationBuilder.DropTable(
                name: "FolderDto");
        }
    }
}
