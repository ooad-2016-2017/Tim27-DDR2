using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Sobarica : Uposlenik
    {
        public Sobarica()
        {
        }

        public Sobarica(string jmb, double plata, DateTime zap,  string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja, gender spol) : base(jmb, plata, zap,  us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja, spol)
        {
        }
    }
}
