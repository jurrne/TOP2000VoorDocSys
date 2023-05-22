using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Top20002.Migrations
{
    /// <inheritdoc />
    public partial class alterspLijst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ALTER PROCEDURE spLijst " +
                "@jaar integer " +
                "AS " +
                "select s.titel, a.naam, l.positie, s.jaar, " +
                "(SELECT positie FROM Lijst l1 " +
                "WHERE jaar = @jaar -1 " +
                "AND l1.songid = l.songid) [Vorigjaar] " +
                "from Lijst l " +
                "inner join Song s on s.songid = l.songid " +
                "inner join Artiest a on a.Artiestid = s.artiestid " +
                "where l.jaar = @jaar " +
                "order by l.positie");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE spLijst");
        }
    }
}
