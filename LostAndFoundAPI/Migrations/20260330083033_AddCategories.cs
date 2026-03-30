using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LostAndFoundAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "FoundItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FoundItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik" },
                    { 2, "Kleidung" },
                    { 3, "Taschen & Rucksäcke" },
                    { 4, "Schlüssel" },
                    { 5, "Dokumente" },
                    { 6, "Sonstiges" }
                });

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_FoundItems_CategoryId",
                table: "FoundItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoundItems_Categories_CategoryId",
                table: "FoundItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoundItems_Categories_CategoryId",
                table: "FoundItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_FoundItems_CategoryId",
                table: "FoundItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoundItems");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FoundItems",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Kleidung");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Elektronik");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Schlüssel");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "Tasche");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "Schmuck");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: "Kleidung");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Category",
                value: "Elektronik");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Category",
                value: "Kleidung");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Category",
                value: "Accessoire");

            migrationBuilder.UpdateData(
                table: "FoundItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Category",
                value: "Tasche");
        }
    }
}
