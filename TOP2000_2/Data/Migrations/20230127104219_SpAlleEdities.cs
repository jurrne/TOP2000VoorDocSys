using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;
using System.Text.RegularExpressions;
using Top2000_2.Models;

#nullable disable

namespace Top20002.Migrations
{
    /// <inheritdoc />
    public partial class SpAlleEdities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spAlleEdities");
            sb.Append(" AS ");
            sb.Append("SELECT DISTINCT Song.songid, Song.titel, Artiest.naam, Song.jaar" +
            " FROM Song " +
            "INNER JOIN Artiest ON Song.artiestid = Artiest.Artiestid " +
            "INNER JOIN Lijst ON Song.songid = Lijst.songid " +
            "GROUP BY Song.songid, Song.titel, Artiest.naam, Song.jaar " +
            "HAVING COUNT(DISTINCT Lijst.jaar) = (SELECT COUNT(DISTINCT jaar) FROM Lijst) " +
            "ORDER BY Song.titel;");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spAlleEdities");
        }
    }
}
