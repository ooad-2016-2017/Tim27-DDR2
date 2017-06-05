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
        string username = "";
        public string Username { get { return username; } set { username = value; } }
        string password = "";
        public string Password { get { return password; } set { password = Encryptor.MD5Hash(value); } }
        public ICommand Logovanje { get; set; }
        public ICommand NewAccount { get; set; }
        public INavigationService NavigationService { get; set; }

        public LogInVM()
        {
            NavigationService = new NavigationService();
            Logovanje = new RelayCommand<object>(FindUser, parametar=>true);
            NewAccount = new RelayCommand<object>(KreiranjeAccounta,parametar=>true);
        }
        
        public void KreiranjeAccounta(object parametar)
        {
            NavigationService.Navigate(typeof(NewAccount));
        }

        public async void FindUser(object parametar)

        {
            Admin novi = new Admin("admin", "admin", "ddr2", "admini", "neka", "bla", "email", "gradic", "12354", new DateTime(1995, 12, 12), Osoba.gender.Female);

            if (Username == "" || Password == "")
            {
                var dialog = new MessageDialog("Invalid login.\nPlease try again.");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
            else
            {
                using (var db = new HotelDbContext())
                {
                    if (db.Korisnici.Count() > 0) 
                    {
                        db.Korisnici.Add(novi);
                        db.SaveChanges();

                        var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == Username && kor.Password == Password);

                        if (korisnik is Admin)
                        {
                            NavigationService.Navigate(typeof(AdminPanel), new AdminPanelVM(this));
                        }
                        else if (korisnik is Sobarica)
                        {
                            NavigationService.Navigate(typeof(RoomCleaning), new RoomCleaningVM(this));
                        }
                        else if (korisnik is Recepcionar)
                        {
                            NavigationService.Navigate(typeof(Reception), new ReceptionVM(this));
                        }
                        else if (korisnik is Gost)
                        {
                            NavigationService.Navigate(typeof(GuestPanel), new GuestPanelVM(this));
                        }
                        else
                        {
                            korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == Username || kor.Password == Password);
                            if (korisnik != null)
                            {
                                if (korisnik.Username == Username && korisnik.Password != Password)
                                {
                                    var dialog = new MessageDialog("Incorrect password.\nPlease try again." + " "+korisnik.Password+" "+Password);
                                    Password = "";
                                    dialog.Title = "Error";
                                    await dialog.ShowAsync();
                                }
                                else if (korisnik.Username != Username && korisnik.Password == Password)
                                {
                                    var dialog = new MessageDialog("Incorrect username.\nPlease try again.");
                                    Username = "";
                                    dialog.Title = "Error";
                                    await dialog.ShowAsync();
                                }
                            }
                            else
                            {
                                var dialog = new MessageDialog("Invalid login.\nPlease try again.");
                                Username = "";
                                Password = "";
                                dialog.Title = "Error";
                                await dialog.ShowAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}
