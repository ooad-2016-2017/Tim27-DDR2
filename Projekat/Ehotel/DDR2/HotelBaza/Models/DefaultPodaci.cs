using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDR2.Model.Rezervacija;
using static DDR2.Model.Soba;

namespace DDR2.HotelBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(HotelDbContext context)
        {
            if (!context.Sobe.Any())
            {
                context.Sobe.AddRange(
                new Soba()
                {
                    Naziv = "Soba pomirenja",
                    Broj = 1,
                    Cijena = 50,
                    Slobodna = true,
                    Ociscena = true,
                    Max_broj_djece = 1,
                    Max_broj_odraslih = 2,
                    Opis = "neka probna sobica",
                    Tip = tip_sobe.family,
                }
                );
            }

            if (!context.Rezervacije.Any())
            {
                context.Rezervacije.AddRange(
                new Rezervacija()
                {
                    GostRezervacije = new Gost()
                    {
                        Ime = "Rahman",
                        Prezime = "Rahmanovic",
                        Drzava = "Etiopija",
                        Grad = "Pjon Jang",
                        Adresa = "bla bal",
                        Email = "hahaha",
                        Telefon = "020202",
                        Username = "username",
                        Password = "password",
                        Dat_rodjenja = new DateTime(2013, 12, 12),
                    },
                    SobaRezervacije = new Soba()
                    {
                        Naziv = "Soba pomirenja",
                        Broj = 1,
                        Cijena = 50,
                        Slobodna = true,
                        Ociscena = true,
                        Max_broj_djece = 1,
                        Max_broj_odraslih = 2,
                        Opis = "neka probna sobica",
                        Tip = tip_sobe.family,
                    },
                    IdRezervacije = "skfvi8g69furigz",
                    Cijena = 500,
                    Br_djece = 1,
                    Br_odraslih = 2,
                    Br_noci = 5,
                    Br_soba = 1,
                    Bazen = false,
                    Parking = true,
                    Smjestaj = TipSmjestaja.halfboard,
                    Check_in = new DateTime(2014, 12, 12),
                    Check_out = new DateTime(2014, 12, 17)
                }
                );

            }
            if (!context.Gosti.Any())
            {
                context.Gosti.AddRange(
                new Gost()
                {
                    Ime = "Rahman",
                    Prezime = "Rahmanovic",
                    Drzava = "Etiopija",
                    Grad = "Pjon Jang",
                    Adresa = "bla bal",
                    Email = "hahaha",
                    Telefon = "020202",
                    Username = "username",
                    Password = "password",
                    Dat_rodjenja = new DateTime(2013, 12, 12),
                }
                );
            }
            if (!context.Recepcionari.Any())
            {
                context.Recepcionari.AddRange(
                new Recepcionar()
                {
                    Ime = "Rahman",
                    Prezime = "Rahmanovic",
                    Drzava = "Etiopija",
                    Grad = "Pjon Jang",
                    Adresa = "bla bal",
                    Email = "hahaha",
                    Telefon = "020202",
                    Username = "username",
                    Password = "password",
                    Dat_rodjenja = new DateTime(1996, 12, 12),
                    Dat_zaposlenja = new DateTime(2013, 12, 12),
                    JMBG = "92838392948",
                    Plata = 213,
                }
                );
            }
            if (!context.Sobarice.Any())
            {
                context.Sobarice.AddRange(
                new Sobarica()
                {
                    Ime = "Rahmana",
                    Prezime = "Rahmanovic",
                    Drzava = "Etiopija",
                    Grad = "Pjon Jang",
                    Adresa = "bla bal",
                    Email = "hahaha",
                    Telefon = "020234202",
                    Username = "username",
                    Password = "password",
                    Dat_rodjenja = new DateTime(1996, 12, 12),
                    Dat_zaposlenja = new DateTime(2013, 12, 12),
                    JMBG = "92838392948",
                    Plata = 213,
                }
                );
            }
        }
    }
}
