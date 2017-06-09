using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDR2.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kartice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Broj = table.Column<string>(nullable: true),
                    DatumIsteka = table.Column<DateTime>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Kod = table.Column<string>(nullable: true),
                    TipKartice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Broj = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Max_djece = table.Column<int>(nullable: false),
                    Max_odraslih = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Ociscena = table.Column<bool>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(type: "image", nullable: true),
                    Slobodna = table.Column<bool>(nullable: false),
                    Tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column<string>(nullable: true),
                    Dat_rodjenja = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Drzava = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol_osobe = table.Column<int>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    KreditnaKarticaId = table.Column<int>(nullable: true),
                    Dat_zaposlenja = table.Column<DateTime>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    Plata = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Kartice_KreditnaKarticaId",
                        column: x => x.KreditnaKarticaId,
                        principalTable: "Kartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bazen = table.Column<bool>(nullable: false),
                    Br_djece = table.Column<int>(nullable: false),
                    Br_noci = table.Column<int>(nullable: false),
                    Br_odraslih = table.Column<int>(nullable: false),
                    Check_in = table.Column<DateTime>(nullable: false),
                    Check_out = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    GostId = table.Column<int>(nullable: true),
                    IsCheckedIn = table.Column<bool>(nullable: false),
                    IsCheckedOut = table.Column<bool>(nullable: false),
                    Parking = table.Column<bool>(nullable: false),
                    Rezervacija_id = table.Column<string>(nullable: true),
                    Smjestaj = table.Column<int>(nullable: false),
                    SobaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Korisnici_GostId",
                        column: x => x.GostId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Sobe_SobaId",
                        column: x => x.SobaId,
                        principalTable: "Sobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KreditnaKarticaId",
                table: "Korisnici",
                column: "KreditnaKarticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_GostId",
                table: "Rezervacije",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_SobaId",
                table: "Rezervacije",
                column: "SobaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "Kartice");
        }
    }
}
