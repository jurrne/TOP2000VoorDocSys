using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spVerwijderdVanLijst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spVerwijderdVanLijst");
            sb.Append(" @jaar integer");
            sb.Append(" AS ");
            sb.Append("SELECT l1.positie, a1.naam, s1.titel, s1.jaar [uitgifteJaar] " +
                "FROM Song s1 " +
                "JOIN Lijst l1 ON l1.SongId = s1.SongId " +
                "JOIN artiest a1 ON a1.Artiestid = s1.artiestid " +
                "WHERE l1.jaar = @jaar - 1 AND " +
                "NOT EXISTS(" +
                "SELECT DISTINCT s2.SongId " +
                "FROM Song s2 " +
                "JOIN Lijst l2 ON l2.SongId = s1.SongId " +
                "where l2.jaar = @jaar) " +
                "ORDER BY l1.positie");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spVerwijderdVanLijst");
        }
    }
}
