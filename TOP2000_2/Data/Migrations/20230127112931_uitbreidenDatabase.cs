using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top20002.Migrations
{
    /// <inheritdoc />
    public partial class uitbreidenDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alter table Artiest " +
                "add biografie varchar(255)," +
                "wikiLink nvarchar(255)," +
                "artiestFoto nvarchar(255);" +
                "" +
                "alter table Song " +
                "add songtekst nvarchar(255)," +
                "songFoto nvarchar(255);");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiest");
            migrationBuilder.DropTable(
                            name: "Song");
        }
    }
}
