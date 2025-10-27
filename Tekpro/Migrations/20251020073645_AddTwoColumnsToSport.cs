using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tekpro.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoColumnsToSport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSinglePlayer",
                table: "Sports",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "IsSinglePlayer",
                table: "Sports");
        }
    }
}
