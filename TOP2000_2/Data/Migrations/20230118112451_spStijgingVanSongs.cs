using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spStijgingVanSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spStijgingVanSongs");
            sb.Append(" @jaar integer");
            sb.Append(" AS ");
            sb.Append("SELECT s.titel ,a.naam ,s.jaar [uitgiftejaar] ,l.positie " +
                ",(SELECT positie FROM Lijst l1 " +
                "WHERE jaar = @jaar -1 " +
                "AND l1.songid = l.songid) [Vorigjaar]" +
                " ,replace(l.positie - " +
                "( SELECT positie FROM Lijst l1" +
                " WHERE jaar = @jaar -1 " +
                "AND l1.songid = l.songid), '-', '') [verschil]" +
                "FROM Lijst l " +
                "INNER JOIN Song s ON l.songid = s.songid " +
                "INNER JOIN Artiest a ON a.Artiestid = s.artiestid " +
                "WHERE l.jaar = @jaar " +
                "AND l.positie < (" +
                "SELECT positie FROM Lijst l1 " +
                "WHERE jaar = @jaar -1 " +
                "AND l1.songid = l.songid)");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spStijgingVanSongs");
        }
    }
}
