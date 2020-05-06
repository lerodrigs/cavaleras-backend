using Microsoft.EntityFrameworkCore.Migrations;

namespace Cavaleras.Data.Migrations
{
    public partial class AddressesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "apto",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "number",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "zipcode",
                schema: "auth",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idclient = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    number = table.Column<string>(nullable: false),
                    apto = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: false),
                    neighborhood = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: false),
                    zipcode = table.Column<string>(nullable: true),
                    selected = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_idclient",
                        column: x => x.idclient,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_idclient",
                table: "Addresses",
                column: "idclient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "address",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "apto",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "number",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
