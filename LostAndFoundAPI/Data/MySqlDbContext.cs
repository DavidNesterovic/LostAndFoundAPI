using LostAndFoundAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LostAndFoundAPI.Data;

public class MySqlDbContext : IdentityDbContext<ApplicationUser>
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
    {
    }

    public DbSet<FoundItem> FoundItems => Set<FoundItem>();
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Elektronik" },
            new Category { Id = 2, Name = "Kleidung" },
            new Category { Id = 3, Name = "Taschen & Rucksäcke" },
            new Category { Id = 4, Name = "Schlüssel" },
            new Category { Id = 5, Name = "Dokumente" },
            new Category { Id = 6, Name = "Sonstiges" }
        );

        modelBuilder.Entity<FoundItem>().HasData(
            new FoundItem
            {
                Id = 1,
                Title = "Schwarze Kappe",
                Description = "Gefunden auf einer Bank beim Bahnhof. Leicht ausgebleicht.",
                CategoryId = 2,
                Color = "Schwarz",
                Location = "Bahnhof Dornbirn",
                ImageUrl = null,
                ContactName = "Max Mustermann",
                ContactEmail = "max.mustermann@mail.at"
            },
            new FoundItem
            {
                Id = 2,
                Title = "iPhone 12",
                Description = "Lag auf dem Boden nahe dem Haupteingang. Display hat einen kleinen Sprung.",
                CategoryId = 1,
                Color = "Blau",
                Location = "FH Vorarlberg",
                ImageUrl = "https://picsum.photos/seed/iphone/800/600",
                ContactName = "Laura Berger",
                ContactEmail = "laura.berger@mail.at"
            },
            new FoundItem
            {
                Id = 3,
                Title = "Schlüsselbund mit Lederanhänger",
                Description = "Mehrere Schlüssel an einem Ring, brauner Lederanhänger.",
                CategoryId = 4,
                Color = "Braun",
                Location = "Marktplatz Dornbirn",
                ImageUrl = "https://picsum.photos/seed/keys/800/600",
                ContactName = "Thomas Huber",
                ContactEmail = "thomas.huber@mail.at"
            },
            new FoundItem
            {
                Id = 4,
                Title = "Roter Rucksack",
                Description = "Gefunden im Bus der Linie 202. Keine sichtbaren Schäden.",
                CategoryId = 3,
                Color = "Rot",
                Location = "Stadtbus Dornbirn",
                ImageUrl = "https://picsum.photos/seed/backpack/800/600",
                ContactName = "Sabrina König",
                ContactEmail = "sabrina.koenig@mail.at"
            },
            new FoundItem
            {
                Id = 5,
                Title = "Goldene Armbanduhr",
                Description = "Lag auf der Toilette im Einkaufszentrum.",
                CategoryId = 6,
                Color = "Gold",
                Location = "Messepark Dornbirn",
                ImageUrl = "https://picsum.photos/seed/watch/800/600",
                ContactName = "Daniel Weiss",
                ContactEmail = "daniel.weiss@mail.at"
            },
            new FoundItem
            {
                Id = 6,
                Title = "Grauer Hoodie",
                Description = "Gefunden beim Sportplatz, Größe M.",
                CategoryId = 2,
                Color = "Grau",
                Location = "Birkenwiese Stadion",
                ImageUrl = "https://picsum.photos/seed/hoodie/800/600",
                ContactName = "Julia Fink",
                ContactEmail = "julia.fink@mail.at"
            },
            new FoundItem
            {
                Id = 7,
                Title = "AirPods Pro",
                Description = "Ohne Case gefunden, lagen unter einer Sitzbank.",
                CategoryId = 1,
                Color = "Weiß",
                Location = "Bahnhof Dornbirn",
                ImageUrl = "https://picsum.photos/seed/airpods/800/600",
                ContactName = "Markus Leitner",
                ContactEmail = "markus.leitner@mail.at"
            },
            new FoundItem
            {
                Id = 8,
                Title = "Kinderhandschuhe",
                Description = "Ein Paar gestrickte Handschuhe, vermutlich für ein Kind.",
                CategoryId = 2,
                Color = "Blau",
                Location = "Stadtgarten Dornbirn",
                ImageUrl = "https://picsum.photos/seed/gloves/800/600",
                ContactName = "Anna Müller",
                ContactEmail = "anna.mueller@mail.at"
            },
            new FoundItem
            {
                Id = 9,
                Title = "Schwarze Geldbörse",
                Description = "Leer, keine Ausweise oder Karten enthalten.",
                CategoryId = 6,
                Color = "Schwarz",
                Location = "Innenstadt Dornbirn",
                ImageUrl = "https://picsum.photos/seed/wallet/800/600",
                ContactName = "Patrick Meier",
                ContactEmail = "patrick.meier@mail.at"
            },
            new FoundItem
            {
                Id = 10,
                Title = "Laptop-Tasche",
                Description = "Gepolsterte Tasche, 15 Zoll. Keine Inhalte.",
                CategoryId = 3,
                Color = "Dunkelgrau",
                Location = "FH Vorarlberg",
                ImageUrl = "https://picsum.photos/seed/laptopbag/800/600",
                ContactName = "Nina Schmid",
                ContactEmail = "nina.schmid@mail.at"
            }
        );
        
        modelBuilder.Entity<FoundItem>()
            .HasOne(f => f.Category)
            .WithMany(c => c.FoundItems)
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}