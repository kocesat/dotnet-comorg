using Microsoft.EntityFrameworkCore.Migrations;

namespace ComorgApp.Data.Migrations
{
    public partial class AddCodeAndNameToParticipantField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeAndName",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeAndName",
                table: "Participants");
        }
    }
}
