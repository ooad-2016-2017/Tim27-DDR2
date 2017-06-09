using DDR2.Helper;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDR2.Model.Osoba;
using static DDR2.Model.Rezervacija;
using static DDR2.Model.Soba;

namespace DDR2.HotelBaza.Models
{
    class DefaultPodaci
    {
        public static Kartica k;
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
                    Max_djece = 1,
                    Max_odraslih = 2,
                    Opis = "neka probna sobica",
                    Tip = tip_sobe.Family,
                }
                );
            }
            if (!context.Kartice.Any())
            {
                k = new Kartica("13vhsjdff", "ddr2", "236432727162", Kartica.Tip.VISA, new DateTime(2020, 10, 22));
                context.Add(k);
            }
            if (!context.Rezervacije.Any())
            {
                context.Rezervacije.AddRange(
                new Rezervacija()
                {
                    Gost = new Gost()
                    {
                        Ime = "Rahman",
                        Prezime = "Rahmanovic",
                        Drzava = "Etiopija",
                        Grad = "Pjon Jang",
                        Adresa = "bla bal",
                        Email = "hahaha",
                        Telefon = "020202",
                        KreditnaKartica=k,
                        Username = "username",
                        Password = "pass",
                        Dat_rodjenja = new DateTime(2013, 12, 12),
                    },
                    Soba = new Soba()
                    {
                        Naziv = "Soba pomirenja",
                        Broj = 1,
                        Cijena = 50,
                        Slobodna = true,
                        Ociscena = true,
                        Max_djece = 1,
                        Max_odraslih = 2,
                        Opis = "neka probna sobica",
                        Tip = tip_sobe.Family,
                    },
                    Rezervacija_id = "skfvi8g69furigz",
                    Cijena = 500,
                    Br_djece = 1,
                    Br_odraslih = 2,
                    Br_noci = 5,
                    Bazen = false,
                    Parking = true,
                    Smjestaj = Tip_smjestaja.halfboard,
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
                    Password = "pass",
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
                    Password = "pass",
                    Dat_rodjenja = new DateTime(1996, 12, 12),
                    Dat_zaposlenja = new DateTime(2013, 12, 12),
                    Jmbg = "92838392948",
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
                    Jmbg = "92838392948",
                    Plata = 213,
                }
                );
            }
            if (!context.Korisnici.Any())
            {
                Recepcionar r = new Recepcionar("150999445454", 1200, new DateTime(2013, 12, 12),"loki", "loki", "berina", "smajovic", "neka", "nka", "dka", "enka", "2154876", new DateTime(1996, 09, 15), gender.Female);
                context.Korisnici.Add(r);

                context.Korisnici.AddRange(
                new Sobarica()
                {
                    Ime = "Berina",
                    Prezime = "Simba",
                    Drzava = "Srbija",
                    Grad = "Beograd",
                    Adresa = "Neka tamo 15",
                    Email = "berinasmajovic@yahoo.com",
                    Telefon = "061666999",
                    Username = "simba",
                    Password = "simba",
                    Dat_rodjenja = new DateTime(1996, 09, 15),
                    Dat_zaposlenja = new DateTime(2013, 12, 12),
                    Jmbg = "1509996100000",
                    Plata = 666,
                });
                context.Korisnici.AddRange(
                new Gost()
                {
                    Ime = "djani",
                    Prezime = "djani",
                    Drzava = "Etiopija",
                    Grad = "Pjon Jang",
                    Adresa = "bla bal",
                    Email = "hahaha",
                    Telefon = "020202",
                    KreditnaKartica=k,
                    Username = "djani",
                    Password = "djani",
                    Dat_rodjenja = new DateTime(2013, 12, 12),
                });
            }
            context.SaveChanges();
        }
    }
}
