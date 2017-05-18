using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Soba
    {
     
        string naziv, opis;
        int broj, max_djece, max_odraslih;
        double cijena;
        bool slobodna, ociscena;
        public enum tip_sobe { single, _double, family };
        tip_sobe tip;

        public Soba(string ime, int broj, int maxd, int maxo, double cijena, bool slobodna, bool cista, tip_sobe tip, string opis)
        {
            Naziv = ime;
            Broj = broj;
            Cijena = cijena;
            Slobodna = slobodna;
            Ociscena = cista;
            Tip = tip;
            Max_djece = maxd;
            Max_odraslih = maxo;
            Opis = opis;
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

        public int Broj
        {
            get
            {
                return broj;
            }

            set
            {
                broj = value;
            }
        }

        public double Cijena
        {
            get
            {
                return cijena;
            }

            set
            {
                cijena = value;
            }
        }
     
        public bool Slobodna
        {
            get
            {
                return slobodna;
            }

            set
            {
                slobodna = value;
            }
        }

        public bool Ociscena
        {
            get
            {
                return ociscena;
            }

            set
            {
                ociscena = value;
            }
        }

        public tip_sobe Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public int Max_djece
        {
            get
            {
                return max_djece;
            }

            set
            {
                max_djece = value;
            }
        }

        public int Max_odraslih
        {
            get
            {
                return max_odraslih;
            }

            set
            {
                max_odraslih = value;
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }

            set
            {
                opis = value;
            }
        }
    }
}
