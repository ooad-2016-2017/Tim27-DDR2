﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public abstract class Korisnik:Osoba
    {
        private string adresa;
        private DateTime dat_rodjenja;
        private string drzava;
        private string email;
        private string grad;
        private string ime;
        private string pass;
        private string prezime;
        private string telefon;
        private string us;
        string username, password;

        public Korisnik(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Username = us;
            Password = pass;
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
    }
}
