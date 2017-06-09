using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Kartica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Kod { get; set; }
        public string Ime { get; set; }
        public string Broj { get; set; }
        public enum Tip { PayPal, VISA, Credit, Master, Debit};
        public Tip TipKartice { get; set; }
        public DateTime DatumIsteka { get; set; }

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
