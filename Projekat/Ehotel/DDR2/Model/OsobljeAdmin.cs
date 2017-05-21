using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class OsobljeAdmin:Admin
    {
        List<Uposlenik> uposleni;

        public OsobljeAdmin(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Uposleni = new List<Uposlenik>();
        }

        public void ObrisiUposlenika(Uposlenik up)
        {
            Uposleni.Remove(up);
        }

        public void DodajUposlenika(Uposlenik up)
        {
            Uposleni.Add(up);
        }

        public List<Uposlenik> Uposleni
        {
            get
            {
                return uposleni;
            }

            set
            {
                uposleni = value;
            }
        }
    }
}
