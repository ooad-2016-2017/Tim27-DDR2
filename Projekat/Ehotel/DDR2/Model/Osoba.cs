using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Osoba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        string ime, prezime, adresa, drzava, email, grad, telefon;
        DateTime dat_rodjenja;
        public enum gender { male, female };
        gender spol_osobe;

        public Osoba()
        {
        }

        public Osoba(string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja, gender spol)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Adresa = adresa;
            this.Drzava = drzava;
            this.Email = email;
            this.Grad = grad;
            this.Telefon = telefon;
            this.Dat_rodjenja = dat_rodjenja;
            this.Spol_osobe = spol;
        }

        public gender Spol_osobe { get => spol_osobe; set => spol_osobe = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public string Email { get => email; set => email = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public DateTime Dat_rodjenja { get => dat_rodjenja; set => dat_rodjenja = value; }
    }
}
