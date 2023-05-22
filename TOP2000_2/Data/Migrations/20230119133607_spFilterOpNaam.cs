using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spFilterOpNaam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spFilterOpNaam");
            sb.Append(" @jaar integer, @naam varchar(75)");
            sb.Append(" AS ");
            sb.Append("Select s.titel, l.positie,  a.naam, s.jaar " +
                "from Song s" +
                " inner join Artiest a on s.artiestid = a.Artiestid " +
                "inner join Lijst l on s.songid = l.songid " +
                "Where a.naam Like @naam and l.jaar = @jaar" +
                " Order by l.positie ");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP procedure spFilterOpNaam");
        }
    }
}
