using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTrackerSystem.Server.Data.Migrations
{
    public partial class AddingDeactiveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deactive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deactive",
                table: "AspNetUsers");
        }
    }
}
