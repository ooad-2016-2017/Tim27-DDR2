using DDR2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDR2.ViewModel
{
    class NumericUpDownVM : MainViewModelBase
    {
        int brojac = 0;
        public string Brojac { get { return brojac.ToString(); } set { brojac = Convert.ToInt32(value); } }
        public ICommand Up { get; set; }
        public ICommand Down { get; set; }

        public NumericUpDownVM()
        {
            Up = new RelayCommand<object>(Povecaj, parametar => true);
            Down = new RelayCommand<object>(Smanji, parametar => true);
        }

        public void Povecaj(object p)
        {
            brojac++;
            Brojac = brojac.ToString();
        }

        public void Smanji(object p)
        {
            brojac--;
            if (brojac <= 0) brojac = 0;
            Brojac = brojac.ToString();
        }
    }
}
