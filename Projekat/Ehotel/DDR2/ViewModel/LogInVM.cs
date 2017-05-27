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

namespace DDR2.ViewModel
{
    class LogInVM : MainViewModelBase
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public ICommand Logovanje { get; set; }
        public ICommand NewAccount { get; set; }
        public INavigationService NavigationService { get; set; }

        public LogInVM()
        {
            NavigationService = new NavigationService();
            Logovanje = new RelayCommand<object>(FindUser);
            NewAccount = new RelayCommand<object>(KreiranjeAccounta,parametar=>true);
        }

        public void KreiranjeAccounta(object parametar)
        {
            NavigationService.Navigate(typeof(NewAccount));
        }

        public async void FindUser(object parametar)
        {
            using (var db = new HotelDbContext())
            {
                if (db.Korisnici.Count() > 0)
                {
                    var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == Username && kor.Password == Password);
                   
                    if (korisnik is Admin)
                    {
                        NavigationService.Navigate(typeof(AdminPanel));
                    }
                    else if (korisnik is Sobarica)
                    {
                        NavigationService.Navigate(typeof(RoomCleaning));
                    }
                    else if (korisnik is Recepcionar)
                    {
                        NavigationService.Navigate(typeof(Reception));
                    }
                    else if (korisnik is Gost)
                    {
                        NavigationService.Navigate(typeof(GuestPanel));
                    }
                }
                else
                {
                    var dialog = new MessageDialog("No user with that username and password!");
                    await dialog.ShowAsync();
                }
            }
        }
    }
}
