using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Recepcionar : Uposlenik
    {
        List<Rezervacija> rezervacije;
        List<Gost> gosti;

        public Recepcionar(string jmb, double plata, DateTime zap, string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(jmb, plata, zap, us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Rezervacije = new List<Rezervacija>();
            Gosti = new List<Gost>();
        }

        public List<Rezervacija> Rezervacije
        {
            get
            {
                return rezervacije;
            }

            set
            {
                rezervacije = value;
            }
        }

        public List<Gost> Gosti
        {
            get
            {
                return gosti;
            }

            set
            {
                gosti = value;
            }
        }
    }
}
