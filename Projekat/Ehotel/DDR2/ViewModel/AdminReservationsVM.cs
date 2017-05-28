using DDR2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDR2.ViewModel
{
    class AdminReservationsVM : MainViewModelBase
    {
        public string Pretraga { get; set; }
        public ICommand Search { get; set; }

        public AdminReservationsVM()
        {
            Search = new RelayCommand<object>(Pretrazi, parametar => true);
        }

        public void Pretrazi(object param)
        {
//najbolje u HotelDbContext implementirati metode za pretragu po imenu i slicno pa ih pozivati ovde da vrate nadjeno u listu jer necemo na sto mjesta pisati kod
        }
    }
}
