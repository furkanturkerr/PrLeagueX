using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrLeagueX.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class deltematchstadiumname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumName",
                table: "Matches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StadiumName",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
