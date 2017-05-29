using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.ViewModel
{
    class ReceptionVM : MainViewModelBase
    {
        public List<Rezervacija> Rezervacije { get; set; }
        public ReceptionVM()
        {
            using (var db = new HotelDbContext())
            {
                Rezervacije = db.Rezervacije.OrderBy(c => c.Cijena).ToList();
            }
        }
    }
}
