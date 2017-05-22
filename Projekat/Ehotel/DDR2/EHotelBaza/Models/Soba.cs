using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDR2.Model.Soba;

namespace DDR2.EHotelBaza.Models
{
    class Soba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SobaId { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public int Broj { get; set; }
        public double Cijena { get; set; }
        public bool Slobodna { get; set; }
        public bool Ociscena { get; set; }
        public tip_sobe Tip { get; set; }
    }
}
