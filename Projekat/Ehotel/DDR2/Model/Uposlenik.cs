using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Uposlenik:Korisnik
    {
        string JMBG;
        double plata;
        DateTime dat_zaposlenja;

        public Uposlenik(string jmb, double plata, DateTime zap, string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            JMBG1 = jmb;
            Plata = plata;
            Dat_zaposlenja = zap;
        }

        public string JMBG1
        {
            get
            {
                return JMBG;
            }

            set
            {
                JMBG = value;
            }
        }

        public double Plata
        {
            get
            {
                return plata;
            }

            set
            {
                plata = value;
            }
        }

        public DateTime Dat_zaposlenja
        {
            get
            {
                return dat_zaposlenja;
            }

            set
            {
                dat_zaposlenja = value;
            }
        }
    }
}
