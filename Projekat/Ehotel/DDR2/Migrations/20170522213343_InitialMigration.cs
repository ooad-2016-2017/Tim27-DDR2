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
                name: "Gost",
                columns: table => new
                {
                    Id = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    Dat_rodjenja = table.Column(type: "TEXT", nullable: false),
                    Drzava = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Grad = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Slika = table.Column(type: "image", nullable: true),
                    Telefon = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.Id);
                });
            migration.CreateTable(
                name: "Recepcionar",
                columns: table => new
                {
                    Id = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    Dat_rodjenja = table.Column(type: "TEXT", nullable: false),
                    Dat_zaposlenja = table.Column(type: "TEXT", nullable: false),
                    Drzava = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Grad = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    JMBG = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Slika = table.Column(type: "image", nullable: true),
                    Telefon = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionar", x => x.Id);
                });
            migration.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    SobaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Broj = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    Max_broj_djece = table.Column(type: "INTEGER", nullable: false),
                    Max_broj_odraslih = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Ociscena = table.Column(type: "INTEGER", nullable: false),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    Slika = table.Column(type: "image", nullable: true),
                    Slobodna = table.Column(type: "INTEGER", nullable: false),
                    Tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaId);
                });
            migration.CreateTable(
                name: "Sobarica",
                columns: table => new
                {
                    Id = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    Dat_rodjenja = table.Column(type: "TEXT", nullable: false),
                    Dat_zaposlenja = table.Column(type: "TEXT", nullable: false),
                    Drzava = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Grad = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    JMBG = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Slika = table.Column(type: "image", nullable: true),
                    Telefon = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobarica", x => x.Id);
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Bazen = table.Column(type: "INTEGER", nullable: false),
                    Br_djece = table.Column(type: "INTEGER", nullable: false),
                    Br_noci = table.Column(type: "INTEGER", nullable: false),
                    Br_odraslih = table.Column(type: "INTEGER", nullable: false),
                    Br_soba = table.Column(type: "INTEGER", nullable: false),
                    Check_in = table.Column(type: "TEXT", nullable: false),
                    Check_out = table.Column(type: "TEXT", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    GostRezervacijeId = table.Column(type: "INTEGER", nullable: true),
                    IdRezervacije = table.Column(type: "TEXT", nullable: true),
                    Parking = table.Column(type: "INTEGER", nullable: false),
                    Smjestaj = table.Column(type: "INTEGER", nullable: false),
                    SobaRezervacijeSobaId = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Gost_GostRezervacijeId",
                        columns: x => x.GostRezervacijeId,
                        referencedTable: "Gost",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Soba_SobaRezervacijeSobaId",
                        columns: x => x.SobaRezervacijeSobaId,
                        referencedTable: "Soba",
                        referencedColumn: "SobaId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Recepcionar");
            migration.DropTable("Rezervacija");
            migration.DropTable("Sobarica");
            migration.DropTable("Gost");
            migration.DropTable("Soba");
        }
    }
}
