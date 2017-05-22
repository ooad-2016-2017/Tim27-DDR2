using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.HotelBaza.Models
{
    class Sobarica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Dat_rodjenja { get; set; }
        public byte[] Slika { get; set; }
        public string JMBG { get; set; }
        public double Plata { get; set; }
        public DateTime Dat_zaposlenja { get; set; }
    }
}
