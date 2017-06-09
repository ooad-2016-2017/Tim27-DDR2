using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DDR2.HotelBaza.Models;
using DDR2.Model;

namespace DDR2.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DDR2.Model.Kartica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Broj");

                    b.Property<DateTime>("DatumIsteka");

                    b.Property<string>("Ime");

                    b.Property<string>("Kod");

                    b.Property<int>("TipKartice");

                    b.HasKey("Id");

                    b.ToTable("Kartice");
                });

            modelBuilder.Entity("DDR2.Model.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("Dat_rodjenja");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Drzava");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol_osobe");

                    b.Property<string>("Telefon");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Korisnik");
                });

            modelBuilder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Bazen");

                    b.Property<int>("Br_djece");

                    b.Property<int>("Br_noci");

                    b.Property<int>("Br_odraslih");

                    b.Property<DateTime>("Check_in");

                    b.Property<DateTime>("Check_out");

                    b.Property<double>("Cijena");

                    b.Property<int?>("GostId");

                    b.Property<bool>("IsCheckedIn");

                    b.Property<bool>("IsCheckedOut");

                    b.Property<bool>("Parking");

                    b.Property<string>("Rezervacija_id");

                    b.Property<int>("Smjestaj");

                    b.Property<int?>("SobaId");

                    b.HasKey("Id");

                    b.HasIndex("GostId");

                    b.HasIndex("SobaId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("DDR2.Model.Soba", b =>
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
                        .HasColumnType("image");

                    b.Property<bool>("Slobodna");

                    b.Property<int>("Tip");

                    b.HasKey("Id");

                    b.ToTable("Sobe");
                });

            modelBuilder.Entity("DDR2.Model.Admin", b =>
                {
                    b.HasBaseType("DDR2.Model.Korisnik");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("DDR2.Model.Gost", b =>
                {
                    b.HasBaseType("DDR2.Model.Korisnik");

                    b.Property<int?>("KreditnaKarticaId");

                    b.HasIndex("KreditnaKarticaId");

                    b.ToTable("Gost");

                    b.HasDiscriminator().HasValue("Gost");
                });

            modelBuilder.Entity("DDR2.Model.Uposlenik", b =>
                {
                    b.HasBaseType("DDR2.Model.Korisnik");

                    b.Property<DateTime>("Dat_zaposlenja");

                    b.Property<string>("Jmbg");

                    b.Property<double>("Plata");

                    b.ToTable("Uposlenik");

                    b.HasDiscriminator().HasValue("Uposlenik");
                });

            modelBuilder.Entity("DDR2.Model.Recepcionar", b =>
                {
                    b.HasBaseType("DDR2.Model.Uposlenik");


                    b.ToTable("Recepcionar");

                    b.HasDiscriminator().HasValue("Recepcionar");
                });

            modelBuilder.Entity("DDR2.Model.Sobarica", b =>
                {
                    b.HasBaseType("DDR2.Model.Uposlenik");


                    b.ToTable("Sobarica");

                    b.HasDiscriminator().HasValue("Sobarica");
                });

            modelBuilder.Entity("DDR2.Model.Rezervacija", b =>
                {
                    b.HasOne("DDR2.Model.Gost", "Gost")
                        .WithMany("Lista_rezervacija")
                        .HasForeignKey("GostId");

                    b.HasOne("DDR2.Model.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaId");
                });

            modelBuilder.Entity("DDR2.Model.Gost", b =>
                {
                    b.HasOne("DDR2.Model.Kartica", "KreditnaKartica")
                        .WithMany()
                        .HasForeignKey("KreditnaKarticaId");
                });
        }
    }
}
