using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using DDR2.HotelBaza.Models;

namespace DDR2Migrations
{
    [ContextType(typeof(HotelDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20170523160031_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("DDR2.Model.Gost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Recepcionar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<DateTime>("Dat_zaposlenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Jmbg");

                    b.Property<string>("Password");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Bazen");

                    b.Property<int>("Br_djece");

                    b.Property<int>("Br_noci");

                    b.Property<int>("Br_odraslih");

                    b.Property<int>("Br_soba");

                    b.Property<DateTime>("Check_in");

                    b.Property<DateTime>("Check_out");

                    b.Property<double>("Cijena");

                    b.Property<int?>("GostId");

                    b.Property<bool>("Parking");

                    b.Property<string>("Rezervacija_id");

                    b.Property<int>("Smjestaj");

                    b.Property<int?>("SobaId");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Soba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Broj");

                    b.Property<double>("Cijena");

                    b.Property<int>("Max_djece");

                    b.Property<int>("Max_odraslih");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Ociscena");

                    b.Property<string>("Opis");

                    b.Property<byte[]>("Slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<bool>("Slobodna");

                    b.Property<int>("Tip");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Sobarica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<DateTime>("Dat_zaposlenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Jmbg");

                    b.Property<string>("Password");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Uposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<DateTime>("Dat_zaposlenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Jmbg");

                    b.Property<string>("Password");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.Reference("DDR2.Model.Gost")
                        .InverseCollection()
                        .ForeignKey("GostId");

                    b.Reference("DDR2.Model.Soba")
                        .InverseCollection()
                        .ForeignKey("SobaId");
                });
        }
    }
}
