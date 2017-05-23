using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Uposlenik : Korisnik
    {
        string jmbg;
        double plata;
        DateTime dat_zaposlenja;

        public Uposlenik()
        {
        }

        public Uposlenik(string jmb, double plata, DateTime zap, string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja, gender spol) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja, spol)
        {
            Jmbg = jmb;
            Plata = plata;
            Dat_zaposlenja = zap;
        }

        public string Jmbg { get => jmbg; set => jmbg = value; }
        public double Plata { get => plata; set => plata = value; }
        public DateTime Dat_zaposlenja { get => dat_zaposlenja; set => dat_zaposlenja = value; }
    }
}
