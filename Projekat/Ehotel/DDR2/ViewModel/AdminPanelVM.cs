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
    class AdminPanelVM
    {
        public string Naslov { get; set; } = "Welcome to eHotel Entrada";
        public LogInVM Parent { get; set; }
        public ICommand Rezervacije { get; set; }
        public ICommand Osoblje { get; set; }
        public ICommand Sobe { get; set; }
        public ICommand Gosti { get; set; }
        public ICommand Statistike { get; set; }
        public ICommand Izvjestaj { get; set; }
        public ICommand Profil { get; set; }
        public ICommand LogOut { get; set; }
        public INavigationService NavigationService { get; set; }

        public AdminPanelVM(LogInVM parent)
        {
            Parent = parent;
            Naslov = KreirajNaslov();
            NavigationService = new NavigationService();
            Rezervacije = new RelayCommand<object>(Rez, parametar => true);
            Osoblje = new RelayCommand<object>(Osob, parametar => true);
            Sobe = new RelayCommand<object>(Soba, parametar => true);
            Gosti = new RelayCommand<object>(Gost, parametar => true);
            Statistike = new RelayCommand<object>(Stat, parametar => true);
            Izvjestaj = new RelayCommand<object>(Izv, parametar => true);
            Profil = new RelayCommand<object>(Prof, parametar => true);
            LogOut = new RelayCommand<object>(Izadji, parametar => true);
        }
        public void Osob(object parametar)
        {
            NavigationService.Navigate(typeof(Staff));//ovde kasnije dodati drugi parametar tima StaffVM ako bude potrebno proslijediti podatke
        }
        public void Izv(object parametar)
        {
            NavigationService.Navigate(typeof(MonthlyReport));
        }
        public void Prof(object parametar)
        {
            NavigationService.Navigate(typeof(ViewProfile),new ViewProfileVM(this));
        }
        public void Rez(object parametar)
        {
            NavigationService.Navigate(typeof(AdminReservations));
        }
        public void Soba(object parametar)
        {
            NavigationService.Navigate(typeof(Rooms));
        }
        public void Gost(object parametar)
        {
            NavigationService.Navigate(typeof(Guests));
        }
        public void Stat(object parametar)
        {
            NavigationService.Navigate(typeof(Statistics));
        }
        public void Izadji(object parametar)
        {
            Parent.NavigationService.GoBack();
        }

        public string KreirajNaslov()
        {
            string naziv = Naslov;
            using (var db=new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == Parent.Username && Encryptor.MD5Hash(kor.Password) == Parent.Password);
                naziv += ", " + korisnik.Ime + " " + korisnik.Prezime;
            }
            return naziv;
        }
    }
}
