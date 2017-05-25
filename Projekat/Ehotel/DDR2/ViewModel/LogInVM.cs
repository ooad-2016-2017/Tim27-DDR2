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
        string username = "";
        string password = "";
        
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand Logovanje
        {
            get
            {
                return new DelegateCommand(FindUser);
            }
        }

        public async void FindUser()
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
