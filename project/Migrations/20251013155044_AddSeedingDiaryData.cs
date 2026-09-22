using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tekpro.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingDiaryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "This is the content of my first diary entry.", new DateTime(2025, 10, 13, 17, 45, 42, 0, DateTimeKind.Unspecified), "First Diary Entry" },
                    { 2, "This is the content of my second diary entry.", new DateTime(2025, 10, 13, 17, 45, 42, 0, DateTimeKind.Unspecified), "Second Diary Entry" },
                    { 3, "This is the content of my third diary entry.", new DateTime(2025, 10, 13, 17, 45, 42, 0, DateTimeKind.Unspecified), "Third Diary Entry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
