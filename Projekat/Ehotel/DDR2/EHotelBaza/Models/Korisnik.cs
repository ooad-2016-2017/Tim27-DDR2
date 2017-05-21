using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DDR2.EHotelBaza.Models
{
    class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; } //primary key u bazi
        public string fourSqaureId { get; set; } //trebat ce za sinkronizaciju
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string drzava { get; set; }
        public string email { get; set; }
        public string grad { get; set; }
        public string telefon{ get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime dat_rodjenja { get; set; }
    }
}
