using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public enum Tip_smjestaja { halfboard, fullboard}
        Gost gost;
        string rezervacija_id;
        bool parking, bazen;
        double cijena;
        Tip_smjestaja smjestaj;
        int br_djece, br_odraslih, br_noci, br_soba;
        DateTime check_in, check_out;
        Soba soba;

        public Rezervacija(Gost g, string id, bool park, bool baz, double cijena, Tip_smjestaja tip, int brd, int bro, int brn, int brs, DateTime cin, DateTime cout)
        {
            Gost = g;
            Rezervacija_id = id;
            Parking = park;
            Bazen = baz;
            Cijena = cijena;
            Smjestaj = tip;
            Br_djece = brd;
            Br_odraslih = bro;
            Br_noci = brn;
            Br_soba = brs;
            Check_in = cin;
            Check_out = cout;
        }

        public Rezervacija()
        {
        }

        public Gost Gost { get => gost; set => gost = value; }
        public string Rezervacija_id { get => rezervacija_id; set => rezervacija_id = value; }
        public bool Parking { get => parking; set => parking = value; }
        public bool Bazen { get => bazen; set => bazen = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public Tip_smjestaja Smjestaj { get => smjestaj; set => smjestaj = value; }
        public int Br_djece { get => br_djece; set => br_djece = value; }
        public int Br_odraslih { get => br_odraslih; set => br_odraslih = value; }
        public int Br_noci { get => br_noci; set => br_noci = value; }
        public int Br_soba { get => br_soba; set => br_soba = value; }
        public DateTime Check_in { get => check_in; set => check_in = value; }
        public DateTime Check_out { get => check_out; set => check_out = value; }
        public Soba Soba { get => soba; set => soba = value; }
    }
}
