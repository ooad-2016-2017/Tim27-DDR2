using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Soba
    {
        string naziv;
        int broj;
        double cijena;
        bool slobodna, ociscena;
        public enum tip_sobe { single, _double, family };
        tip_sobe tip;

        public Soba(string ime, int broj, double cijena, bool slobodna, bool cista, tip_sobe tip)
        {
            Naziv = ime;
            Broj = broj;
            Cijena = cijena;
            Slobodna = slobodna;
            Ociscena = cista;
            Tip = tip;
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
    }
}
