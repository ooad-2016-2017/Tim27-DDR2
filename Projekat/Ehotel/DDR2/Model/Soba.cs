using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Soba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public enum tip_sobe { single, _double, triple, family };
        string naziv, opis;
        int broj, max_djece, max_odraslih;
        double cijena;
        bool slobodna, ociscena;
        tip_sobe tip;
        byte[] slika;

        public Soba(string ime, int broj, double cijena, bool slobodna, bool cista, tip_sobe tip, int djeca, int odrasli, string opis)
        {
            Naziv = ime;
            Broj = broj;
            Cijena = cijena;
            Slobodna = slobodna;
            Ociscena = cista;
            Tip = tip;
            Max_djece = djeca;
            Max_odraslih = odrasli;
            Opis = opis;
        }

        public Soba()
        {
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public int Broj { get => broj; set => broj = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public bool Slobodna { get => slobodna; set => slobodna = value; }
        public bool Ociscena { get => ociscena; set => ociscena = value; }
        public tip_sobe Tip { get => tip; set => tip = value; }
        public string Opis { get => opis; set => opis = value; }
        public int Max_djece { get => max_djece; set => max_djece = value; }
        public int Max_odraslih { get => max_odraslih; set => max_odraslih = value; }
        public byte[] Slika { get => slika; set => slika = value; }
    }
}
