using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spEenKeerInTop2000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spEenKeerInTop2000");
            sb.Append(" AS ");
            sb.Append(" SELECT a.naam as Artiest, s.titel as Titel, s.jaar as Uitgiftejaar, l.positie as Positie, l.jaar as TOP2000jaar " +
                "FROM Lijst l " +
                "INNER JOIN Song s ON l.songid = s.songid " +
                "INNER JOIN Artiest a ON a.Artiestid = s.artiestid " +
                "WHERE s.songid in (SELECT l1.songid FROM Lijst l1 GROUP BY l1.songid HAVING COUNT(*) = 1) " +
                "ORDER BY a.naam, s.titel;");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spEenKeerInTop2000");
        }
    }
}
