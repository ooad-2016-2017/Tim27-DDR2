using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using DDR2.RezervacijeBaza.Models;

namespace DDR2Migrations
{
    [ContextType(typeof(rezervacijaDbContext))]
    partial class rezervacijaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("DDR2.Model.Gost", b =>
                {
                    b.Property<int>("Id");

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
                    b.Property<int>("Id");

                    b.Property<string>("Id_rezervacije");

                    b.Property<bool>("Bazen");

                    b.Property<int>("Br_djece");

                    b.Property<int>("Br_noci");

                    b.Property<int>("Br_odraslih");

                    b.Property<int>("Br_soba");

                    b.Property<DateTime>("Check_in");

                    b.Property<DateTime>("Check_out");

                    b.Property<double>("Cijena");

                    b.Property<int>("GostId");

                    b.Property<bool>("Parking");

                    b.Property<int>("Smjestaj");

                    b.Property<int>("SobaID");

                    b.Key("Id");
                });

            builder.Entity("DDR2.Model.Soba", b =>
                {
                    b.Property<int>("ID");

                    b.Property<int>("Broj");

                    b.Property<int>("Max_djece");

                    b.Property<int>("Max_odraslih");

                    b.Property<double>("Cijena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Ociscena");

                    b.Property<bool>("Slobodna");

                    b.Property<int>("Tip");

                    b.Property<string>("Opis");

                    b.Key("ID");
                });

            builder.Entity("DDR2.RezervacijeBaza.Models.rezervacija", b =>
                {
                    b.Property<int>("id").ValueGeneratedOnAdd();

                    b.Property<string>("Id_rezervacije");

                    b.Property<bool>("bazen");

                    b.Property<int>("br_djece");

                    b.Property<int>("br_noci");

                    b.Property<int>("br_odraslih");

                    b.Property<int>("br_soba");

                    b.Property<DateTime>("check_in");

                    b.Property<DateTime>("check_out");

                    b.Property<double>("cijena");

                    b.Property<int>("gostId");

                    b.Property<bool>("parking");

                    b.Property<int>("smjestaj");

                    b.Property<int>("sobaID");

                    b.Key("id");
                });

     /*       builder.Entity("DDR2.Model.Rezervacija", b =>
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
                });*/
        }
    }
}
