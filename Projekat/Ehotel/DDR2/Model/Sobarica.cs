using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Sobarica : Uposlenik
    {
        List<Soba> sobe;

        public Sobarica(string jmb, double plata, DateTime zap, string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(jmb, plata, zap, us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Sobe = new List<Soba>();
        }

        public List<Soba> Sobe
        {
            get
            {
                return sobe;
            }

            set
            {
                sobe = value;
            }
        }
    }
}
