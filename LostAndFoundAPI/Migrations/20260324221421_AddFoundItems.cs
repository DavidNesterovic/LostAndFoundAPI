using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LostAndFoundAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFoundItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    ContactName = table.Column<string>(type: "longtext", nullable: false),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundItems", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "FoundItems",
                columns: new[] { "Id", "Category", "Color", "ContactEmail", "ContactName", "Description", "ImageUrl", "Location", "Title" },
                values: new object[,]
                {
                    { 1, "Kleidung", "Schwarz", "max.mustermann@mail.at", "Max Mustermann", "Gefunden auf einer Bank beim Bahnhof. Leicht ausgebleicht.", null, "Bahnhof Dornbirn", "Schwarze Kappe" },
                    { 2, "Elektronik", "Blau", "laura.berger@mail.at", "Laura Berger", "Lag auf dem Boden nahe dem Haupteingang. Display hat einen kleinen Sprung.", "https://picsum.photos/seed/iphone/800/600", "FH Vorarlberg", "iPhone 12" },
                    { 3, "Schlüssel", "Braun", "thomas.huber@mail.at", "Thomas Huber", "Mehrere Schlüssel an einem Ring, brauner Lederanhänger.", "https://picsum.photos/seed/keys/800/600", "Marktplatz Dornbirn", "Schlüsselbund mit Lederanhänger" },
                    { 4, "Tasche", "Rot", "sabrina.koenig@mail.at", "Sabrina König", "Gefunden im Bus der Linie 202. Keine sichtbaren Schäden.", "https://picsum.photos/seed/backpack/800/600", "Stadtbus Dornbirn", "Roter Rucksack" },
                    { 5, "Schmuck", "Gold", "daniel.weiss@mail.at", "Daniel Weiss", "Lag auf der Toilette im Einkaufszentrum.", "https://picsum.photos/seed/watch/800/600", "Messepark Dornbirn", "Goldene Armbanduhr" },
                    { 6, "Kleidung", "Grau", "julia.fink@mail.at", "Julia Fink", "Gefunden beim Sportplatz, Größe M.", "https://picsum.photos/seed/hoodie/800/600", "Birkenwiese Stadion", "Grauer Hoodie" },
                    { 7, "Elektronik", "Weiß", "markus.leitner@mail.at", "Markus Leitner", "Ohne Case gefunden, lagen unter einer Sitzbank.", "https://picsum.photos/seed/airpods/800/600", "Bahnhof Dornbirn", "AirPods Pro" },
                    { 8, "Kleidung", "Blau", "anna.mueller@mail.at", "Anna Müller", "Ein Paar gestrickte Handschuhe, vermutlich für ein Kind.", "https://picsum.photos/seed/gloves/800/600", "Stadtgarten Dornbirn", "Kinderhandschuhe" },
                    { 9, "Accessoire", "Schwarz", "patrick.meier@mail.at", "Patrick Meier", "Leer, keine Ausweise oder Karten enthalten.", "https://picsum.photos/seed/wallet/800/600", "Innenstadt Dornbirn", "Schwarze Geldbörse" },
                    { 10, "Tasche", "Dunkelgrau", "nina.schmid@mail.at", "Nina Schmid", "Gepolsterte Tasche, 15 Zoll. Keine Inhalte.", "https://picsum.photos/seed/laptopbag/800/600", "FH Vorarlberg", "Laptop-Tasche" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoundItems");
        }
    }
}
