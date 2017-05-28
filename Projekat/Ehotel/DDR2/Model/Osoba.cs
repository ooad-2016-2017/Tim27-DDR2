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
        public enum gender { Male, Female };
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

        public gender Spol_osobe
        {
            get
            {
                return spol_osobe;
            }

            set
            {
                spol_osobe = value;
            }
        }
    }
}
