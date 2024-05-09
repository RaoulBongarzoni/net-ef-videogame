using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwareHouse",
                columns: table => new
                {
                    SoftwareHouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwareHouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouse", x => x.SoftwareHouseId);
                });

            migrationBuilder.CreateTable(
                name: "Videogame",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideogameDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideogameRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftwareHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogame", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogame_SoftwareHouse_SoftwareHouseId",
                        column: x => x.SoftwareHouseId,
                        principalTable: "SoftwareHouse",
                        principalColumn: "SoftwareHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareHouse_SoftwareHouseId",
                table: "SoftwareHouse",
                column: "SoftwareHouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videogame_SoftwareHouseId",
                table: "Videogame",
                column: "SoftwareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogame_VideogameName",
                table: "Videogame",
                column: "VideogameName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videogame");

            migrationBuilder.DropTable(
                name: "SoftwareHouse");
        }
    }
}
