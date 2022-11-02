using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocuManage.Data.Migrations
{
    public partial class DtoUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FolderDto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FolderDto");
        }
    }
}
