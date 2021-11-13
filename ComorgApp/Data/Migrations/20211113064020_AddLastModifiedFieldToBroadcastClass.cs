using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComorgApp.Data.Migrations
{
    public partial class AddLastModifiedFieldToBroadcastClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Broadcasts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Broadcasts");
        }
    }
}
