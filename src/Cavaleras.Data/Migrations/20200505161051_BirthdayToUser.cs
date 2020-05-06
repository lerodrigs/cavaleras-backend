using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cavaleras.Data.Migrations
{
    public partial class BirthdayToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                schema: "auth",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthday",
                schema: "auth",
                table: "Users");
        }
    }
}
