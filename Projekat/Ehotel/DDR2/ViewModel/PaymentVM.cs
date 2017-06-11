using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using static DDR2.Model.Kartica;

namespace DDR2.ViewModel
{
    class PaymentVM : MainViewModelBase
    {
        Tip tip;
        public string TipPlacanja { get { return tip.ToString(); } set { tip = (Tip)Enum.Parse(typeof(Tip), value); } }
        public List<String> TipoviPlacanja { get; set; } = new List<string> { "VISA", "Master", "Credit", "PayPal", "Debit" };
        public string Ime { get; set; }
        public string Broj { get; set; }
        public string SigKod { get; set; }
        public DateTime DatumIsteka { get; set; }
        public ICommand Potvrdi { get; set; }
        public NewReservationVM Parent { get; set; }
        public INavigationService NavigationService { get; set; }

        public PaymentVM(NewReservationVM p)
        {
            Parent = p;
            NavigationService = new NavigationService();
            Potvrdi = new RelayCommand<object>(potvrda, parametar => true);
        }

        public async void potvrda(object p)
        {
            using (var db = new HotelDbContext())
            {
                var gost = db.Gosti.FirstOrDefault(kor => kor.Username == Parent.Parent.Parent.Username && kor.Password == Parent.Parent.Parent.Password);
                Kartica k = new Kartica(SigKod, Ime, Broj, tip, DatumIsteka);
                Rezervacija r = new Rezervacija(gost, "A345gdh", Parent.ImaLiParking, Parent.ImaLiBazen, Convert.ToDouble(Parent.Total), Parent.tip, Parent.djeca, Parent.odrasli, Parent.djeca, Parent.SobaIznajmljena.Broj, Parent.CheckIn, Parent.CheckOut, false, false);
                gost.KreditnaKartica = k;
                if (gost.Lista_rezervacija==null)
                {
                    gost.Lista_rezervacija = new List<Rezervacija>();
                }
                gost.Lista_rezervacija.Add(r);
                db.Rezervacije.Add(r);
                db.SaveChanges();
                var dialog = new MessageDialog("You made a payment. Thank you for booking.");
                await dialog.ShowAsync();
            }
        }
    }
}
