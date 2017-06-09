using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDR2.ViewModel
{
    class GuestPanelVM : MainViewModelBase
    {
        public string Naslov { get; set; } = "Welcome to eHotel Entrada";
        public LogInVM Parent { get; set; }
        public ICommand Rezervacije { get; set; }
        public ICommand NovaRezervacija { get; set; }
        public ICommand Mapa { get; set; }
        public ICommand Profil { get; set; }
        public ICommand LogOut { get; set; }
        public INavigationService NavigationService { get; set; }

        public GuestPanelVM(LogInVM parent)
        {
            Parent = parent;
            Naslov = KreirajNaslov();
            NavigationService = new NavigationService();
            Rezervacije = new RelayCommand<object>(Rez, parametar => true);
            NovaRezervacija = new RelayCommand<object>(novarez, parametar => true);
            Mapa = new RelayCommand<object>(mapa, parametar => true);
            Profil = new RelayCommand<object>(Prof, parametar => true);
            LogOut = new RelayCommand<object>(Izadji, parametar => true);
        }
        public void novarez(object parametar)
        {
            NavigationService.Navigate(typeof(NewReservation), new NewReservationVM(this)); 
        }
        public void mapa(object parametar)
        {
            NavigationService.Navigate(typeof(ShowMap));
        }
        public void Prof(object parametar)
        {
            NavigationService.Navigate(typeof(ViewProfile), new ViewProfileVM(this));
        }
        public void Rez(object parametar)
        {
            NavigationService.Navigate(typeof(GuestReservation));
        }
        public void Izadji(object parametar)
        {
            Parent.NavigationService.GoBack();
        }

        public string KreirajNaslov()
        {
            string naziv = Naslov;
            using (var db = new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == Parent.Username && kor.Password == Parent.Password);
                naziv += ", " + korisnik.Ime + " " + korisnik.Prezime;
            }
            return naziv;
        }
    }
}
