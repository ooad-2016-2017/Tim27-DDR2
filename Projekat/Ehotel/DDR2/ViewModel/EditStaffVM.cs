using DDR2.Helper;
using DDR2.HotelBaza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using static DDR2.Model.Osoba;

namespace DDR2.ViewModel
{
    class EditStaffVM : MainViewModelBase
    {
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public gender spol;
        public double plata = 0;
        public string Posao { get; set; } = "";
        public List<string> Drzave { get; set; }
        public List<String> Poslovi { get; set; } = new List<string> { "Receptionist", "Maid" };
        public string JMBG { get; set; } = "";
        public DateTime DatumZaposlenja { get; set; } = DateTime.Now;
        public double Plata { get { return plata; } set { plata = Convert.ToDouble(value); } }

        public string Spol_osobe { get { return spol.ToString(); } set { spol = (gender)Enum.Parse(typeof(gender), value); } }
        int id;
        public string Id { get { return id.ToString(); } set { id = Convert.ToInt32(value); } }

        public DateTime Dat_rodjenja { get; set; }

        public ICommand Save { get; set; }
        public StaffVM ListaRoditelj { get; set; }

        public EditStaffVM(StaffVM parent)
        {
            ListaRoditelj = parent;
            InicijalizirajPodatke();
            Save = new RelayCommand<object>(spasi, parametar => true);
        }

        public void InicijalizirajPodatke()
        {
            using (var db = new HotelDbContext())
            {
                var uposlenik = db.Uposlenici.FirstOrDefault(x => x == ListaRoditelj.Selektovan);
                Username = uposlenik.Username;
                Password = uposlenik.Password;
                Ime = uposlenik.Ime;
                Prezime = uposlenik.Prezime;
                Email = uposlenik.Email;
                Telefon = uposlenik.Telefon;
                Drzava = uposlenik.Drzava;
                Grad = uposlenik.Grad;
                Adresa = uposlenik.Adresa;
                Spol_osobe = uposlenik.Spol_osobe.ToString();
                plata = uposlenik.Plata;
                JMBG = uposlenik.Jmbg;
                
            }
        }

        public async void spasi(object p)
        {
            using (var db = new HotelDbContext())
            {
                var promijeniti = db.Uposlenici.FirstOrDefault(x => x == ListaRoditelj.Selektovan);
                promijeniti.Username = Username;
                promijeniti.Password = Password;
                promijeniti.Ime = Ime;
                promijeniti.Prezime = Prezime;
                promijeniti.Email = Email;
                promijeniti.Telefon = Telefon;
                promijeniti.Drzava = Drzava;
                promijeniti.Grad = Grad;
                promijeniti.Adresa = Adresa;
                promijeniti.Spol_osobe = spol;
                promijeniti.Plata = plata;
                promijeniti.Jmbg = JMBG;


                db.Entry(promijeniti).State = EntityState.Modified;
                db.SaveChanges();
                var dialog = new MessageDialog("Changes saved!");
                await dialog.ShowAsync();
            }
        }
    }
}

