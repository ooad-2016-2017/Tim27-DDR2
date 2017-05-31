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
    class GuestsVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Brisi { get; set; }
        public ICommand Edituj { get; set; }
        public ICommand AddGuest { get; set; }
        public Gost Selektovan { get; set; }
        public ObservableCollection<Gost> GostiListe { get; set; }
        public INavigationService NavigationService { get; set; }

        public GuestsVM()
        {
            using (var db = new HotelDbContext())
            {
                GostiListe = new ObservableCollection<Gost>(db.Gosti.OrderBy(c => c.Id).ToList());
            }
            NavigationService = new NavigationService();
            Edituj = new RelayCommand<object>(edit, p => true);
            Brisi = new RelayCommand<object>(obrisi, p => true);
            AddGuest = new RelayCommand<object>(dodaj, p => true);
        }

        public async void obrisi(object p)
        {
            if (Selektovan != null)
            {
                var pitanje = new MessageDialog("Are you sure you want to delete selected guest?");
                pitanje.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 0 });
                pitanje.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 1 });
                pitanje.DefaultCommandIndex = 0;
                pitanje.CancelCommandIndex = 1;
                await pitanje.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected guest!");
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
                    db.Gosti.Remove(Selektovan);
                    db.SaveChanges();
                    var dialog = new MessageDialog("You have deleted guest " + Selektovan.Ime);
                    await dialog.ShowAsync();
                    GostiListe.Remove(Selektovan);
                }
            }
        }

        public void dodaj(object p)
        {
            NavigationService.Navigate(typeof(NewGuest));
        }

        public async void edit(object p)
        {
            if (Selektovan != null) NavigationService.Navigate(typeof(EditGuest), new EditGuestVM(this));
            else
            {
                var dialog = new MessageDialog("You haven't selected guest!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
    }
}
