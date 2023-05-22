using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class sp3ArtiestenMetMeesteNummer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE sp3ArtiestenMetMeesteNummer");
            sb.Append(" @jaar integer");
            sb.Append(" AS ");
            sb.Append(" SELECT a.naam, COUNT(a.naam) as Aantal, AVG(positie) as Gemiddelde, Min(l.positie) as Hoogste " +
                "from Artiest a " +
                "inner join Song s ON s.artiestid = a.Artiestid " +
                "inner join Lijst l ON l.songid = s.songid " +
                "where l.jaar = @jaar " +
                "group by a.naam " +
                "order by COUNT(*) desc");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure sp3ArtiestenMetMeesteNummer");
        }
    }
}