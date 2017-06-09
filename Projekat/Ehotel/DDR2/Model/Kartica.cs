using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Kartica
    {
        //dodati id za bazu i ubaciti u korisnika
        string Kod { get; set; }
        string Ime { get; set; }
        string Broj { get; set; }
        public enum Tip { PayPal, VISA, Credit, Master, Debit};
        Tip TipKartice { get; set; }
        DateTime DatumIsteka { get; set; }

        public Kartica()
        {
        }

        public Kartica(string k, string i, string b, Tip t, DateTime d)
        {
            Kod = k;
            Ime = i;
            Broj = b;
            TipKartice = t;
            DatumIsteka = d;
        }
    }
}
