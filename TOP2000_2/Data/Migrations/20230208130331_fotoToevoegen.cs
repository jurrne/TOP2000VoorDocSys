using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Top20002.Migrations
{
    /// <inheritdoc />
    public partial class fotoToevoegen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE PROCEDURE spFotoToevoegen " +
                "@song nvarchar(255), " +
                "@foto nvarchar(255) " +
                "AS " +
                "UPDATE Song " +
                "SET songFoto = @foto " +
                "WHERE titel like @song;");
            migrationBuilder.Sql(sb.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE spFotoToevoegen");
        }
    }
}
