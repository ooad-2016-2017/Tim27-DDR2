using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDR2.ViewModel
{
    class RoomsVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }
        public ICommand Brisi { get; set; }
        public Soba Selektovana { get; set; }
        public List<Soba> SobeListe { get; set; }

        public RoomsVM()
        {
            Brisi = new RelayCommand<object>(obrisi, p => true);
            using(var db=new HotelDbContext())
            {
                SobeListe = db.Sobe.OrderBy(c => c.Broj).ToList();
            }
        }

        public void obrisi(object p)
        {
            using (var db = new HotelDbContext())
            {
                db.Sobe.Remove(Selektovana);
                db.SaveChanges();
                SobeListe = db.Sobe.OrderBy(c => c.Broj).ToList();
            }
        }
    }
}
