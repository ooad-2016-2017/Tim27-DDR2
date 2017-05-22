using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDR2.Model.Soba;

namespace DDR2.EHotelBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(SobaDbContext context)
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
                    Tip = tip_sobe.family,
                }
                );
                context.SaveChanges();
            }
        }
    }
}
