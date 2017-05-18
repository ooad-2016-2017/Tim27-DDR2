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
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    Dat_rodjenja = table.Column(type: "TEXT", nullable: false),
                    Drzava = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Grad = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Telefon = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.Id);
                });

            migration.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
                    Broj = table.Column(type: "INTEGER", nullable: false),
                    Max_djece = table.Column(type: "INTEGER", nullable: false),
                    Max_odraslih = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Ociscena = table.Column(type: "INTEGER", nullable: false),
                    Slobodna = table.Column(type: "INTEGER", nullable: false),
                    Tip = table.Column(type: "INTEGER", nullable: false),
                    Opis = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.ID);
                });

            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column(type: "INTEGER", nullable: false),
                    Id_rezervacije = table.Column(type: "TEXT", nullable: false),
                    Bazen = table.Column(type: "INTEGER", nullable: false),
                    Br_djece = table.Column(type: "INTEGER", nullable: false),
                    Br_noci = table.Column(type: "INTEGER", nullable: false),
                    Br_odraslih = table.Column(type: "INTEGER", nullable: false),
                    Br_soba = table.Column(type: "INTEGER", nullable: false),
                    Check_in = table.Column(type: "TEXT", nullable: false),
                    Check_out = table.Column(type: "TEXT", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    GostId = table.Column(type: "INTEGER", nullable: true),
                    Parking = table.Column(type: "INTEGER", nullable: false),
                    Smjestaj = table.Column(type: "INTEGER", nullable: false),
                    SobaID = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Gost_GostId",
                        columns: x => x.GostId,
                        referencedTable: "Gost",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Soba_SobaID",
                        columns: x => x.SobaID,
                        referencedTable: "Soba",
                        referencedColumn: "ID");
                });

            migration.CreateTable(
                name: "rezervacija",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    Id_rezervacije = table.Column(type: "TEXT" , nullable: false),
                    bazen = table.Column(type: "INTEGER", nullable: false),
                    br_djece = table.Column(type: "INTEGER", nullable: false),
                    br_noci = table.Column(type: "INTEGER", nullable: false),
                    br_odraslih = table.Column(type: "INTEGER", nullable: false),
                    br_soba = table.Column(type: "INTEGER", nullable: false),
                    check_in = table.Column(type: "TEXT", nullable: false),
                    check_out = table.Column(type: "TEXT", nullable: false),
                    cijena = table.Column(type: "REAL", nullable: false),
                    gostId = table.Column(type: "INTEGER", nullable: true),
                    parking = table.Column(type: "INTEGER", nullable: false),
                    smjestaj = table.Column(type: "INTEGER", nullable: false),
                    sobaID = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_rezervacija_Gost_gostId",
                        columns: x => x.gostId,
                        referencedTable: "Gost",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rezervacija_Soba_sobaID",
                        columns: x => x.sobaID,
                        referencedTable: "Soba",
                        referencedColumn: "ID");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Rezervacija");
            migration.DropTable("rezervacija");
            migration.DropTable("Gost");
            migration.DropTable("Soba");
        }
    }
}
