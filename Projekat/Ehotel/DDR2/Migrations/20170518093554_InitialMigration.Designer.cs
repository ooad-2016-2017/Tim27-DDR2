using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using DDR2.RezervacijeBaza.Models;

namespace DDR2Migrations
{
    [ContextType(typeof(rezervacijaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20170518093554_InitialMigration"; }
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
                    b.Property<string>("Id");

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("Bazen");

                    b.Property<int>("Br_djece");

                    b.Property<int>("Br_noci");

                    b.Property<int>("Br_odraslih");

                    b.Property<int>("Br_soba");

                    b.Property<DateTime>("Check_in");

                    b.Property<DateTime>("Check_out");

                    b.Property<double>("Cijena");

                    b.Property<string>("GostId");

                    b.Property<bool>("Parking");

                    b.Property<int>("Smjestaj");

                    b.Property<string>("SobaID");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Soba", b =>
                {
                    b.Property<string>("ID");

                    b.Property<int>("Broj");

                    b.Property<double>("Cijena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Ociscena");

                    b.Property<bool>("Slobodna");

                    b.Property<int>("Tip");

                    b.Key("ID");
                });

            builder.Entity("DDR2.RezervacijeBaza.Models.rezervacija", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("bazen");

                    b.Property<int>("br_djece");

                    b.Property<int>("br_noci");

                    b.Property<int>("br_odraslih");

                    b.Property<int>("br_soba");

                    b.Property<DateTime>("check_in");

                    b.Property<DateTime>("check_out");

                    b.Property<double>("cijena");

                    b.Property<string>("gostId");

                    b.Property<bool>("parking");

                    b.Property<int>("smjestaj");

                    b.Property<string>("sobaID");

                    b.Key("id");
                });

            builder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.Reference("DDR2.Model.Gost")
                        .InverseCollection()
                        .ForeignKey("GostId");

                    b.Reference("DDR2.Model.Soba")
                        .InverseCollection()
                        .ForeignKey("SobaID");
                });

            builder.Entity("DDR2.RezervacijeBaza.Models.rezervacija", b =>
                {
                    b.Reference("DDR2.Model.Gost")
                        .InverseCollection()
                        .ForeignKey("gostId");

                    b.Reference("DDR2.Model.Soba")
                        .InverseCollection()
                        .ForeignKey("sobaID");
                });
        }
    }
}
