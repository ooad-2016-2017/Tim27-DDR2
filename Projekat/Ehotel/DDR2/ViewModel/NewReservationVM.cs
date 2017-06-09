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
using static DDR2.Model.Rezervacija;
using static DDR2.Model.Soba;

namespace DDR2.ViewModel
{
    class NewReservationVM : MainViewModelBase
    {
        public Soba SobaIznajmljena { get; set; }
        public Tip_smjestaja tip;
        public string TipSmjestaja { get { return tip.ToString(); } set { tip = (Tip_smjestaja)Enum.Parse(typeof(Tip_smjestaja), value); } }
        public List<String> TipoviSmjestaja { get; set; } = new List<string> { "halfboard", "fullboard"};
        public tip_sobe tips;
        public string TipSobe { get { return tips.ToString(); } set { tips = (tip_sobe)Enum.Parse(typeof(tip_sobe), value); } }
        public List<String> TipoviSobe { get; set; } = new List<string> { "Single", "Double", "Triple", "Family" };
        public bool ImaLiBazen { get; set; } = false;
        public bool ImaLiParking { get; set; } = false;
        public String Total { get; set; }
        public int odrasli;
        public int djeca;
        public int noci;
        public string Odrasli { get { return odrasli.ToString(); } set { odrasli = Convert.ToInt32(value); } }
        public string Djeca { get { return djeca.ToString(); } set { djeca = Convert.ToInt32(value); } }
        public string Noci { get { return noci.ToString(); } set { noci = Convert.ToInt32(value); } }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public GuestPanelVM Parent { get; set; }
        public ICommand Naredno { get; set; }
        public ICommand Cijena { get; set; }
        public INavigationService NavigationService { get; set; }

        public NewReservationVM(GuestPanelVM p)
        {
            Parent = p;
            NavigationService = new NavigationService();
            Naredno = new RelayCommand<object>(placanje, parametar => true);
            Cijena = new RelayCommand<object>(obracunaj, parametar => true);
        }

        public async void obracunaj(object p)
        {
            double cijena = 0;
            if (TipSmjestaja == "halfboard") cijena += 50;
            else if (TipSmjestaja == "fullboard") cijena += 100;
            if (ImaLiBazen) cijena += 35;
            if (ImaLiParking) cijena += 25;

            using (var db = new HotelDbContext())
            {
                var sobaZaIznajmiti = db.Sobe.FirstOrDefault(soba => soba.Max_djece >= djeca && soba.Max_odraslih >= odrasli && soba.Tip == tips && soba.Slobodna == true);
                if (sobaZaIznajmiti != null)
                {
                    SobaIznajmljena = sobaZaIznajmiti;
                    cijena += noci * sobaZaIznajmiti.Cijena;
                    Total = cijena.ToString();
                }
                else
                {
                    Total = "";
                    var dialog = new MessageDialog("No available rooms with that characteristics. Please try another options.");
                    await dialog.ShowAsync();
                }
            }
        }

        public void placanje(object parametar)
        {
            NavigationService.Navigate(typeof(payment), new PaymentVM(this));
        }
    }
}
