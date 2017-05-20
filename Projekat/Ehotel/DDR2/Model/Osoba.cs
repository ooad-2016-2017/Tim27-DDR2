using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Osoba
    {
        string ime, prezime, adresa, drzava, email, grad, telefon;
        DateTime dat_rodjenja;

        public Osoba(string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.drzava = drzava;
            this.email = email;
            this.grad = grad;
            this.telefon = telefon;
            this.dat_rodjenja = dat_rodjenja;
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public string Adresa
        {
            get
            {
                return adresa;
            }

            set
            {
                adresa = value;
            }
        }

        public string Drzava
        {
            get
            {
                return drzava;
            }

            set
            {
                drzava = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Grad
        {
            get
            {
                return grad;
            }

            set
            {
                grad = value;
            }
        }

        public string Telefon
        {
            get
            {
                return telefon;
            }

            set
            {
                telefon = value;
            }
        }

        public DateTime Dat_rodjenja
        {
            get
            {
                return dat_rodjenja;
            }

            set
            {
                dat_rodjenja = value;
            }
        }

        enum gender { male, female};  
    }
}
