using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTemporada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Temporada",
                table: "Obras",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temporada",
                table: "Obras");
        }
    }
}
