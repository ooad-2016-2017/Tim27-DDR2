using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace DDR2Migrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                     // .Annotation("Sqlite:Autoincrement", true),
                    adresa = table.Column(type: "TEXT", nullable: true),
                    dat_rodjenja = table.Column(type: "TEXT", nullable: false),
                    drzava = table.Column(type: "TEXT", nullable: true),
                    email = table.Column(type: "TEXT", nullable: true),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true),
                    grad = table.Column(type: "TEXT", nullable: true),
                    ime = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    telefon = table.Column(type: "TEXT", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Korisnik");
        }
    }
}
