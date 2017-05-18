using DDR2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.RezervacijeBaza.Models
{
    class rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int sobaID { get; set; }
        public int gostId { get; set; }

        public Gost gost { get; set; }
        public bool parking { get; set; }
        public string Id_rezervacije { get; set; }
        public bool bazen { get; set; }
        public double cijena { get; set; }
        public enum TipSmjestaja { halfboard, fullboard };
        public TipSmjestaja smjestaj { get; set; }
        public int br_djece { get; set; }
        public int br_odraslih { get; set; }
        public int br_noci { get; set; }
        public int br_soba { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public Soba soba { get; set; }

    }
}
