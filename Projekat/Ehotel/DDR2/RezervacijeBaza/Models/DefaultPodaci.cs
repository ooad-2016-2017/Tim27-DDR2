using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using static DDR2.Model.Rezervacija;

namespace DDR2.RezervacijeBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(rezervacijaDbContext context)
        {
            if (!context.Rezervacije.Any())
            {
                context.Rezervacije.AddRange(
                        new rezervacija()
                        {
                            id = 1,
                            Id_rezervacije = "Ac10000",
                            gost = new Gost(1, "loki_malamu", "pass", "loki", "simba", "adresa1", "drzava1", "email1", "grad1", "062827365", Convert.ToDateTime("01/08/2008")),
                            parking = true,
                            bazen = true,
                            cijena = 100, 
                            smjestaj = rezervacija.TipSmjestaja.halfboard,
                            br_djece = 1,
                            br_odraslih = 1,
                            br_noci = 2,
                            br_soba = 1,
                            check_in = Convert.ToDateTime("01/08/2016"),
                            check_out = Convert.ToDateTime("03/08/2016"),
                            soba = new Soba(1, "sunshine", 1, 1, 1, 100, true, true, Soba.tip_sobe._double, "Soba sa pogledom na more, lijepo osvjetljena.")
                        }
                    );
                context.SaveChanges();
             }
        }
    }
}
