using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostAndFoundAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToFoundItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FoundItems",
                type: "longtext",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "FoundItems",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactName",
                value: "Max Mustermann");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContactName",
                value: "Laura Berger");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ContactName",
                value: "Thomas Huber");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ContactName",
                value: "Sabrina König");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ContactName",
                value: "Daniel Weiss");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ContactName",
                value: "Julia Fink");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ContactName",
                value: "Markus Leitner");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "ContactName",
                value: "Anna Müller");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "ContactName",
                value: "Patrick Meier");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "ContactName",
                value: "Nina Schmid");
        }
    }
}
