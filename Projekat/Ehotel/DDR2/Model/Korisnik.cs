using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Korisnik:Osoba
    {
        string username, password;

        public Korisnik()
        {
        }

        public Korisnik(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja, gender spol) : base(ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja, spol)
        {
            Username = us;
            Password = pass;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
