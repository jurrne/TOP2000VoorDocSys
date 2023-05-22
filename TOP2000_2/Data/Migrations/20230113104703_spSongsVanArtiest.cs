using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;
using Top2000_2.Models;

#nullable disable

namespace Top2000_2.Migrations
{
    /// <inheritdoc />
    public partial class spSongsVanArtiest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder(); 
            sb.Append("CREATE PROCEDURE spLijst"); 
            sb.Append(" @jaar integer"); 
            sb.Append(" AS"); 
            sb.Append(" select l.jaar, s.titel, a.naam, l.positie"); 
            sb.Append(" from Lijst l");
            sb.Append(" inner join Song s on s.songid = l.songid");
            sb.Append(" inner join Artiest a on a.Artiestid = s.artiestid");
            sb.Append(" where l.jaar = @jaar"); 
            sb.Append(" order by l.positie");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE spLijst");
        }
    }
}
