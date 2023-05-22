using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artiest",
                columns: table => new
                {
                    Artiestid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiest", x => x.Artiestid);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    songid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titel = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    jaar = table.Column<int>(type: "int", nullable: false),
                    artiestid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.songid);
                    table.ForeignKey(
                        name: "FK_Song_Artiest_artiestid",
                        column: x => x.artiestid,
                        principalTable: "Artiest",
                        principalColumn: "Artiestid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lijst",
                columns: table => new
                {
                    jaar = table.Column<int>(type: "int", nullable: false),
                    songid = table.Column<int>(type: "int", nullable: false),
                    positie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijst", x => new { x.jaar, x.songid });
                    table.ForeignKey(
                        name: "FK_Lijst_Song_songid",
                        column: x => x.songid,
                        principalTable: "Song",
                        principalColumn: "songid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lijst_songid",
                table: "Lijst",
                column: "songid");

            migrationBuilder.CreateIndex(
                name: "IX_Song_artiestid",
                table: "Song",
                column: "artiestid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lijst");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Artiest");
        }
    }
}
