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

namespace DDR2.ViewModel
{
    class NewGuestVM: MainViewModelBase
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
       
        public ICommand AddGuest { get; set; }

        public NewGuestVM()
        {
            
            AddGuest= new RelayCommand<object>(dodaj, parametar => true);
            using (var db = new HotelDbContext()) Id = db.Gosti.Last().Id++.ToString();
        }

        public async void dodaj(object p)
        {
            Gost nova = new Gost(Username, Password, Ime, Prezime, Adresa, Drzava, Email, Grad, Telefon, Dat_rodjenja,spol, new Kartica());
            
            using (var db = new HotelDbContext())
            {
                db.Gosti.Add(nova);
                db.SaveChanges();

                var poruka = new MessageDialog("Guest " + nova.Ime + " created successfully!");
                await poruka.ShowAsync();
            }
        }
    }
}
