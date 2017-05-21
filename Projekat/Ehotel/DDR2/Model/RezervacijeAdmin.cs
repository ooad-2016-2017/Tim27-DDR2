using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class RezervacijeAdmin:Admin
    {
        List<Rezervacija> rezervacije;

        public RezervacijeAdmin(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Rezervacije = new List<Rezervacija>();
        }

        public void ObrisiRezervaciju(Rezervacija rez)
        {
            Rezervacije.Remove(rez);
        }

        public void DodajRezervaciju(Rezervacija rez)
        {
            Rezervacije.Add(rez);
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
    }
}
