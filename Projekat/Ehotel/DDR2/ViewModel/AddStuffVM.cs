using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static DDR2.Model.Osoba;

namespace DDR2.ViewModel
{
    class AddStuffVM : MainViewModelBase
    {
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
        public string Drzava { get; set; } = "";
        public gender Spol { get; set; }
        public string Posao { get; set; } = "";
        public string JMBG { get; set; } = "";
        public List<string> Drzave { get; set; }
        public DateTime DatumRodjenja { get; set; } = DateTime.Now;
        public DateTime DatumZaposlenja { get; set; } = DateTime.Now;
        double plata = 0;
        public string Plata { get { return plata.ToString(); } set { plata = Convert.ToDouble(value); } }
        Uposlenik NoviUposlenik;
        public ICommand Add { get; set; }

    }
}
