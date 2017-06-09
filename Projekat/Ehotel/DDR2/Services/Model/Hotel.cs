using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Hotel
    {
        public string fourSqaureId { get; set; }
        string Naziv { get; set; }
        string Adresa { get; set; }
        string Telefon { get; set; }
        string Opis { get; set; }
        int Ocjena { get; set; }

        public Hotel(string n, string a, string t, string op, int oc)
        {
            Naziv = n;
            Adresa = a;
            Telefon = t;
            Opis = op;
            Ocjena = oc;
        }
    }
}
