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
                name: "Soba",
                columns: table => new
                {
                    SobaId = table.Column(type: "INTEGER", nullable: false),
                     //   .Annotation("Sqlite:Autoincrement", true),
                    Broj = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Ociscena = table.Column(type: "INTEGER", nullable: false),
                    Slika = table.Column(type: "image", nullable: true),
                    Slobodna = table.Column(type: "INTEGER", nullable: false),
                    Tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Soba");
        }
    }
}
