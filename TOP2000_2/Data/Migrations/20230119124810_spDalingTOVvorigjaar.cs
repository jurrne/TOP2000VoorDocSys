using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spDalingTOVvorigjaar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spDalingTOVvorigjaar");
            sb.Append(" @jaar integer");
            sb.Append(" AS ");
            sb.Append("SELECT s.titel ,a.naam ,s.jaar ,l.positie ," +
                "(SELECT positie" +
                " FROM Lijst l1" +
                " WHERE jaar = 2019 " +
                "AND l1.songid = l.songid) [Vorigjaar], " +
                "replace(( SELECT positie  " +
                "FROM Lijst l1 " +
                "WHERE jaar = 2019" +
                " AND l1.songid = l.songid) - l.positie, '-', '' )[Gedaald]" +
                " FROM Lijst l" +
                " INNER JOIN Song s ON l.songid = s.songid" +
                " INNER JOIN Artiest a ON a.Artiestid = s.artiestid" +
                " WHERE l.jaar = 2020" +
                " and l.positie > " +
                "(SELECT positie" +
                " FROM Lijst l1" +
                " WHERE jaar = 2019" +
                " AND l1.songid = l.songid)");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spDalingTOVvorigjaar");
        }
    }
}