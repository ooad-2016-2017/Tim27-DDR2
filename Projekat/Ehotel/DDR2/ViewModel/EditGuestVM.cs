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
    class EditGuestVM: MainViewModelBase
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
        gender spol;
        public string Spol_osobe { get { return spol.ToString(); } set { spol = (gender)Enum.Parse(typeof(gender), value); } }
        int id;
        public string Id { get { return id.ToString(); } set { id = Convert.ToInt32(value); } }

        public DateTime Dat_rodjenja { get; set; }

        public ICommand Save { get; set; }
        public GuestsVM ListaRoditelj { get; set; }

        public EditGuestVM(GuestsVM parent)
        {
            ListaRoditelj = parent;
            InicijalizirajPodatke();
            Save = new RelayCommand<object>(spasi, parametar => true);
        }

        public void InicijalizirajPodatke()
        {
            using (var db = new HotelDbContext())
            {
                var gost = db.Gosti.FirstOrDefault(x => x == ListaRoditelj.Selektovan);
                Username = gost.Username;
                Password = gost.Password;
                Ime = gost.Ime;
                Prezime = gost.Prezime;
                Email = gost.Email;
                Telefon = gost.Telefon;
                Drzava = gost.Drzava;
                Grad = gost.Grad;
                Adresa = gost.Adresa;
                Spol_osobe = gost.Spol_osobe.ToString();
            }
        }
        
        public async void spasi(object p)
        {
            using (var db = new HotelDbContext())
            {
                var promijeniti = db.Gosti.FirstOrDefault(x => x == ListaRoditelj.Selektovan);
                promijeniti.Username = Username;
                promijeniti.Password = Password;
                promijeniti.Ime = Ime;
                promijeniti.Prezime = Prezime;
                promijeniti.Email = Email;
                promijeniti.Telefon = Telefon;
                promijeniti.Drzava =Drzava;
                promijeniti.Grad = Grad;
                promijeniti.Adresa = Adresa;
                promijeniti.Spol_osobe = spol;

                db.Entry(promijeniti).State = EntityState.Modified;
                db.SaveChanges();
                var dialog = new MessageDialog("Changes saved!");
                await dialog.ShowAsync();
            }
        }
    }
}

