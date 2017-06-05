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

namespace DDR2.ViewModel
{
    class RoomCleaningVM :MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Ocisti { get; set; }
        public ICommand PrikaziOciscene { get; set; }
        public ICommand PrikaziNeociscene { get; set; }
        public ICommand Profil { get; set; }
        public ICommand LogOut { get; set; }
        public Soba Selektovana { get; set; }
        public LogInVM Parent { get; set; }
        public ObservableCollection<Soba> SobeListe { get; set; }
        public ObservableCollection<Soba> Ciste { get; set; }
        public ObservableCollection<Soba> Neciste { get; set; }
        public INavigationService NavigationService { get; set; }

        public RoomCleaningVM(LogInVM parent)
        {
            Parent = parent;
            using (var db = new HotelDbContext())
            {
                SobeListe = new ObservableCollection<Soba>(db.Sobe.OrderBy(c => c.Broj).ToList());
                Ciste = new ObservableCollection<Soba>();
                Neciste = new ObservableCollection<Soba>();
                List<Soba> pomocna = db.Sobe.ToList();
                for (int i = 0; i < pomocna.Count(); i++)
                {
                    if (pomocna[i].Ociscena) Ciste.Add(pomocna[i]);
                    else Neciste.Add(pomocna[i]);
                }
            }
            NavigationService = new NavigationService();
            PrikaziNeociscene = new RelayCommand<object>(neociscene, p => true);
            PrikaziOciscene = new RelayCommand<object>(ociscene, p => true);
            LogOut = new RelayCommand<object>(izadji, p => true);
            Profil = new RelayCommand<object>(profil, p => true);
            Ocisti = new RelayCommand<object>(clean, p => true);
        }
        public void profil(object parametar)
        {
            NavigationService.Navigate(typeof(ViewProfile), new ViewProfileVM(this));
        }
        public void izadji(object parametar)
        {
            NavigationService.Navigate(typeof(Prijava));
        }
        public void neociscene(object p)
        {
            SobeListe.Clear();
            using (var db = new HotelDbContext())
            {
                for (int i = 0; i < Neciste.Count(); i++) SobeListe.Add(Neciste[i]);
            }
        }
        public void ociscene(object p)
        {
            SobeListe.Clear();
            using (var db = new HotelDbContext())
            {
                for (int i = 0; i < Ciste.Count(); i++) SobeListe.Add(Ciste[i]);
            }
        }
        public async void clean(object p)
        {
            if (Selektovana != null)
            {
                using (var db = new HotelDbContext())
                {
                    var izmjenjena = db.Sobe.FirstOrDefault(v => v == Selektovana);
                    izmjenjena.Ociscena = true;
                    db.SaveChanges();
                    SobeListe.Remove(Selektovana);
                    SobeListe.Add(izmjenjena);
                }
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected room!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
    }
}
