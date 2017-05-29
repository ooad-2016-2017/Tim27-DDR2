using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using DDR2.View;
using System;
using System.Collections.Generic;
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
        public List<Rezervacija> Rezervacije { get; set; }
        public ICommand CekiraneRez { get; set; }
        public ICommand OdekiraneRez { get; set; }
        public ICommand LogOut { get; set; }
        public ICommand Profil { get; set; }
        public INavigationService NavigationService { get; set; }
        public LogInVM Parent { get; set; }

        public ReceptionVM(LogInVM parent)
        {
            using (var db = new HotelDbContext())
            {
                Rezervacije = db.Rezervacije.OrderBy(c => c.Cijena).ToList();
            }
            Parent = parent;
            NavigationService = new NavigationService();
            CekiraneRez = new RelayCommand<object>(cekirane, parametar => true);
            OdekiraneRez = new RelayCommand<object>(odcekirane, parametar => true);
            LogOut = new RelayCommand<object>(izadji, parametar => true);
            Profil = new RelayCommand<object>(pogledajProfil, parametar => true);
        }

        public void pogledajProfil(object p)
        {
            NavigationService.Navigate(typeof(ViewProfile), new ViewProfileVM(this));
        }
        public void cekirane(object p)
        {
            using (var db = new HotelDbContext())
            {
                Rezervacije = db.Rezervacije.ToList();
                for(int i = 0; i < Rezervacije.Count(); i++)
                {
                    if (!Rezervacije[i].IsCheckedIn) Rezervacije.Remove(Rezervacije[i]);
                }
            }
        }
        public void odcekirane(object p)
        {
            using (var db = new HotelDbContext())
            {
                Rezervacije = db.Rezervacije.ToList();
                for (int i = 0; i < Rezervacije.Count(); i++)
                {
                    if (!Rezervacije[i].IsCheckedOut) Rezervacije.Remove(Rezervacije[i]);
                }
            }
        }
        public void izadji(object p)
        {
            NavigationService.Navigate(typeof(Prijava));
        }
    }
}
