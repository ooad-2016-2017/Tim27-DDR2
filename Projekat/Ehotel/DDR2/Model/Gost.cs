using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Gost:Korisnik
    {
        List<Rezervacija> lista_rezervacija;
        public Kartica KreditnaKartica { get; set; }

        public Gost()
        {
        }

        public Gost(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja, gender spol, Kartica k) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja, spol)
        {
            KreditnaKartica = k;
            Lista_rezervacija = new List<Rezervacija>();
        }

        public List<Rezervacija> Lista_rezervacija
        {
            get
            {
                return lista_rezervacija;
            }

            set
            {
                lista_rezervacija = value;
            }
            
        }
        
    }
}
