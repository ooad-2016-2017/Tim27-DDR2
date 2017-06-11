using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
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
    class AdminReservationsVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Delete { get; set; }
        public Rezervacija Selektovana { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public ObservableCollection<Rezervacija> RezervacijeListe { get; set; }
        public INavigationService NavigationService { get; set; }
        public AdminReservationsVM()
        {
            
                using (var db = new HotelDbContext())
                {
                    RezervacijeListe = new ObservableCollection<Rezervacija>(db.Rezervacije.OrderBy(c => c.Id).ToList());
                }
            NavigationService = new NavigationService();
            Search = new RelayCommand<object>(Pretrazi, parametar => true);
            Delete = new RelayCommand<object>(delete, p => true);
        }
        public async void delete(object p)
        {
            if (Selektovana != null)
            {
                var pitanje = new MessageDialog("Are you sure you want to delete selected reservation?");
                pitanje.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 0 });
                pitanje.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 1 });
                pitanje.DefaultCommandIndex = 0;
                pitanje.CancelCommandIndex = 1;
                await pitanje.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected reservation!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
        

        private async void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Yes")
            {
                using (var db = new HotelDbContext())
                {
                    db.Rezervacije.Remove(Selektovana);
                    db.SaveChanges();
                    var dialog = new MessageDialog("You have deleted reservation " );
                    await dialog.ShowAsync();
                    RezervacijeListe.Remove(Selektovana);
                }
            }
        }

        public void Pretrazi(object param)
        {
//najbolje u HotelDbContext implementirati metode za pretragu po imenu i slicno pa ih pozivati ovde da vrate nadjeno u listu jer necemo na sto mjesta pisati kod
        }
    }
}
