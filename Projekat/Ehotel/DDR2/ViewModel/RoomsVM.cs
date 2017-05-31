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
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace DDR2.ViewModel
{
    class RoomsVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Brisi { get; set; }
        public ICommand Edituj { get; set; }
        public ICommand AddRoom { get; set; }
        public Soba Selektovana { get; set; }
        public ObservableCollection<Soba> SobeListe { get; set; }
        public INavigationService NavigationService { get; set; }

        public RoomsVM()
        {
            using (var db = new HotelDbContext())
            {
                SobeListe = new ObservableCollection<Soba>(db.Sobe.OrderBy(c => c.Broj).ToList());
            }
            NavigationService = new NavigationService();
            Edituj = new RelayCommand<object>(edit, p => true);
            Brisi = new RelayCommand<object>(obrisi, p => true);
            AddRoom = new RelayCommand<object>(dodaj, p => true);
        }

        public async void obrisi(object p)
        {
            if (Selektovana != null)
            {
                var pitanje = new MessageDialog("Are you sure you want to delete selected room?");
                pitanje.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 0 });
                pitanje.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 1 });
                pitanje.DefaultCommandIndex = 0;
                pitanje.CancelCommandIndex = 1;
                await pitanje.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected room!");
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
                    db.Sobe.Remove(Selektovana);
                    db.SaveChanges();
                    var dialog = new MessageDialog("You have deleted room " + Selektovana.Naziv);
                    await dialog.ShowAsync();
                    SobeListe.Remove(Selektovana);
                }
            }
        }

        public void dodaj(object p)
        {
            NavigationService.Navigate(typeof(NewRoom));
        }

        public async void edit(object p)
        {
           if(Selektovana!=null) NavigationService.Navigate(typeof(EditRoom), new EditRoomVM(this));
           else
            {
                var dialog = new MessageDialog("You haven't selected room!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
    }
}
