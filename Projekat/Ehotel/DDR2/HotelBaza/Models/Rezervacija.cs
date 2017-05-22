using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDR2.Model.Rezervacija;

namespace DDR2.HotelBaza.Models
{
    class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Gost GostRezervacije { get; set; }
        public string IdRezervacije { get; set; }
        public bool Parking { get; set; }
        public bool Bazen { get; set; }
        public double Cijena { get; set; }
        public TipSmjestaja Smjestaj { get; set; }
        public int Br_djece { get; set; }
        public int Br_odraslih { get; set; }
        public int Br_noci { get; set; }
        public int Br_soba { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public Soba SobaRezervacije { get; set; }
    }
}
