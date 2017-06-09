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
    class StaffVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Brisi { get; set; }
        public ICommand Edituj { get; set; }
        public ICommand Add { get; set; }
        public Uposlenik Selektovan { get; set; }
        public ObservableCollection<Uposlenik> UposleniciListe { get; set; }
        public INavigationService NavigationService { get; set; }
        public string Posao { get; set; }
        public DateTime DatumZaposlenja { get; set; }

        public StaffVM()
        {
            using (var db = new HotelDbContext())
            {
                UposleniciListe = new ObservableCollection<Uposlenik>(db.Uposlenici.OrderBy(c => c.Id).ToList());
            }
            NavigationService = new NavigationService();
            Edituj = new RelayCommand<object>(edit, p => true);
            Brisi = new RelayCommand<object>(obrisi, p => true);
            Add = new RelayCommand<object>(dodaj, p => true);
        }

        public async void obrisi(object p)
        {
            if (Selektovan != null)
            {
                var pitanje = new MessageDialog("Are you sure you want to delete selected staff?");
                pitanje.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 0 });
                pitanje.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)) { Id = 1 });
                pitanje.DefaultCommandIndex = 0;
                pitanje.CancelCommandIndex = 1;
                await pitanje.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("You haven't selected staff!");
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
                    db.Uposlenici.Remove(Selektovan);
                    db.SaveChanges();
                    var dialog = new MessageDialog("You have deleted staff " + Selektovan.Ime);
                    await dialog.ShowAsync();
                    UposleniciListe.Remove(Selektovan);
                }
            }
        }

        public void dodaj(object p)
        {
            NavigationService.Navigate(typeof(AddStuff));
        }

        public async void edit(object p)
        {
            if (Selektovan != null) NavigationService.Navigate(typeof(EditStaff), new EditStaffVM(this));
            else
            {
                var dialog = new MessageDialog("You haven't selected staff!");
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }
    }
}

