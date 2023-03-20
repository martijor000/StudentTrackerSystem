using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTrackerSystem.Server.Data.Migrations
{
    public partial class FixedSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deactive",
                table: "AspNetUsers",
                newName: "Deactivate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deactivate",
                table: "AspNetUsers",
                newName: "Deactive");
        }
    }
}
