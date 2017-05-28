using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using static DDR2.Model.Osoba;
using DDR2.ViewModel;

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
        public List<String> Poslovi { get; set; } = new List<string> { "Receptionist", "Maid" };
        public DateTime DatumRodjenja { get; set; } = DateTime.Now;
        public DateTime DatumZaposlenja { get; set; } = DateTime.Now;
        double plata = 0;
        public double Plata { get { return plata; } set { plata = Convert.ToDouble(value); } }
        public ICommand Add { get; set; }

        public AddStuffVM()
        {
            Add = new RelayCommand<object>(DodajOsoblje, ProvjeriPolja);
            Drzave = NewAccountVM.PopuniDrzave(Drzave);
        }

        public async void DodajOsoblje(object param)
        {
            using (var db = new HotelDbContext())
            {
                if (Posao == "Receptionist")
                {
                    Recepcionar NoviUposlenik = new Recepcionar(JMBG, Plata, DatumZaposlenja, Username, Password, Ime, Prezime, Adresa, Drzava, Email, Grad, Telefon, DatumRodjenja, Spol);
                    db.Recepcionari.Add(NoviUposlenik);
                    db.Uposlenici.Add(NoviUposlenik);
                    db.Korisnici.Add(NoviUposlenik);
                }
                else if (Posao == "Maid")
                {
                    Sobarica NoviUposlenik = new Sobarica(JMBG, Plata, DatumZaposlenja, Username, Password, Ime, Prezime, Adresa, Drzava, Email, Grad, Telefon, DatumRodjenja, Spol);
                    db.Sobarice.Add(NoviUposlenik);
                    db.Uposlenici.Add(NoviUposlenik);
                    db.Korisnici.Add(NoviUposlenik);
                }
                db.SaveChanges();
                var dialog = new MessageDialog("Employee added succesfully!\n");
                await dialog.ShowAsync();
            }
        }

        public bool ProvjeriPolja(object param)
        {
            return true;
        }
    }
}
