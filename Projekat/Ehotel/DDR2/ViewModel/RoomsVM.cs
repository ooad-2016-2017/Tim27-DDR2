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

    }
}
