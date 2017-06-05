using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using DDR2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DDR2.ViewModel
{
    class ReceptionVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand PrikaziCekirane { get; set; }
        public ICommand PrikaziOdcekirane { get; set; }
        public ICommand Cekiraj { get; set; }
        public ICommand Odcekiraj { get; set; }
        public ICommand LogOut { get; set; }
        public ICommand Profil { get; set; }
        public INavigationService NavigationService { get; set; }
        public Rezervacija Selektovana { get; set; }
        public LogInVM Parent { get; set; }
        public ObservableCollection<Rezervacija> RezervacijeLista { get; set; }
        public ObservableCollection<Rezervacija> Cekirane { get; set; }
        public ObservableCollection<Rezervacija> Odcekirane { get; set; }

        public ReceptionVM(LogInVM parent)
        {
            using (var db = new HotelDbContext())
            {
                RezervacijeLista = new ObservableCollection<Rezervacija>(db.Rezervacije.OrderBy(c => c.Cijena).ToList());
                Cekirane = new ObservableCollection<Rezervacija>();
                Odcekirane = new ObservableCollection<Rezervacija>();
                List<Rezervacija> pomocna = db.Rezervacije.ToList();
                for (int i = 0; i < pomocna.Count(); i++)
                {
                    if (pomocna[i].IsCheckedIn) Cekirane.Add(pomocna[i]);
                    else Odcekirane.Add(pomocna[i]);
                }
            }
            Parent = parent;
            NavigationService = new NavigationService();
            PrikaziCekirane = new RelayCommand<object>(cekirane, parametar => true);
            PrikaziOdcekirane = new RelayCommand<object>(odcekirane, parametar => true);
            LogOut = new RelayCommand<object>(izadji, parametar => true);
            Profil = new RelayCommand<object>(pogledajProfil, parametar => true);
            Cekiraj = new RelayCommand<object>(checkin, parametar => true);
            Odcekiraj = new RelayCommand<object>(checkout, parametar => true);
        }

        public void pogledajProfil(object p)
        {
            NavigationService.Navigate(typeof(ViewProfile), new ViewProfileVM(this));
        }
        public void cekirane(object p)
        {
            RezervacijeLista.Clear();
            using (var db = new HotelDbContext())
            {
                for (int i = 0; i < Cekirane.Count(); i++) RezervacijeLista.Add(Cekirane[i]);
            }
        }
        public void odcekirane(object p)
        {
            RezervacijeLista.Clear();
            using (var db = new HotelDbContext())
            {
                for (int i = 0; i < Odcekirane.Count(); i++) RezervacijeLista.Add(Odcekirane[i]);
            }
        }
        public void izadji(object p)
        {
            NavigationService.Navigate(typeof(Prijava));
        }
        public async void checkin(object p)
        {
            if (Selektovana != null)
            {
                using (var db = new HotelDbContext())
                {
                    var izmjenjena = db.Rezervacije.FirstOrDefault(v => v == Selektovana);
                    izmjenjena.IsCheckedIn = true;
                    db.SaveChanges();
                    RezervacijeLista.Remove(Selektovana);
                    RezervacijeLista.Add(izmjenjena);
                }
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected reservation!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
        public async void checkout(object p)
        {
            if (Selektovana != null)
            {
                using (var db = new HotelDbContext())
                {
                    var izmjenjena = db.Rezervacije.FirstOrDefault(v => v == Selektovana);
                    izmjenjena.IsCheckedOut = true;
                    db.SaveChanges();
                    RezervacijeLista.Remove(Selektovana);
                    RezervacijeLista.Add(izmjenjena);
                }
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected reservation!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
    }
}
