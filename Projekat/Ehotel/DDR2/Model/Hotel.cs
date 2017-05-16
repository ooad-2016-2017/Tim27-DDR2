using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Hotel
    {
        string naziv;
        List<Gost> gosti;
        List<Uposlenik> uposlenici;
        List<Soba> sobe;
        List<Korisnik> korisnici_sistema;

        public Hotel(string ime)
        {
            Naziv = ime;
            Gosti = new List<Gost>();
            Uposlenici = new List<Uposlenik>();
            Sobe = new List<Soba>();
            Korisnici_sistema = new List<Korisnik>();
        }

        public List<Gost> Gosti
        {
            get
            {
                return gosti;
            }

            set
            {
                gosti = value;
            }
        }

        public List<Uposlenik> Uposlenici
        {
            get
            {
                return uposlenici;
            }

            set
            {
                uposlenici = value;
            }
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

        public List<Korisnik> Korisnici_sistema
        {
            get
            {
                return korisnici_sistema;
            }

            set
            {
                korisnici_sistema = value;
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }
    }
}
