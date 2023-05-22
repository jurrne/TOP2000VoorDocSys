using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;


#nullable disable

namespace Top20002.Migrations
{
    /// <inheritdoc />
    public partial class sp8 : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("CREATE PROCEDURE sp8");
			sb.Append(" AS ");
			sb.Append("SELECT positie, titel, naam, song.jaar" +
			" FROM Song " +
			"INNER JOIN Lijst " +
			"ON Lijst.songid = Song.songid " +
			"INNER JOIN Artiest " +
			"ON Artiest.artiestid = Song.artiestid " +
			"WHERE Lijst.jaar = 2020 AND Artiest.artiestid in " +
			"(SELECT a.artiestid " +
			"FROM Song " +
			"INNER JOIN Artiest a " +
			"ON a.artiestid = Song.artiestid " +
			"INNER JOIN Lijst l " +
			"ON l.songid = Song.songid " +
			"WHERE(l.positie - 1 = Lijst.positie OR l.positie + 1 = Lijst.positie) and l.jaar = 2020) ");
			migrationBuilder.Sql(sb.ToString());
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"DROP procedure sp8");
		}
	}
}
