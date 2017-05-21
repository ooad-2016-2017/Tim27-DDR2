using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.EHotelBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(KorisnikDBContext context)
        {
            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                new Korisnik()
                {
                   ime="Dzejlan",
                   prezime="Sabic",
                   adresa="Ive Andrica 2",
                   drzava="Bosna i Hercegovina",
                   email="dzejlan.sabic@hotmail.com",
                   grad="Sarajevo",
                   telefon="062/297-999",
                   username="dzejlan",
                   password="dzejlan",
                   dat_rodjenja=new DateTime (2017,12,12),
                }
                );
                context.SaveChanges();
            }
        }
    }
}
