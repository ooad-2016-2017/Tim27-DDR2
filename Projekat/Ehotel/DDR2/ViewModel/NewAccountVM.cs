using DDR2.Helper;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDR2.ViewModel
{
    class NewAccountVM : MainViewModelBase
    {
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Drzava { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
        public bool MaleChecked { get; set; } = false;
        public bool FemaleChecked { get; set; } = false;
        //public Gost NoviGost { get; set; }
        public ICommand Create { get; set; }
        public INavigationService NavigationService { get; set; }

        public NewAccountVM()
        {
            NavigationService = new NavigationService();
            Create = new RelayCommand<object>(KreirajAccount,ProvjeriPolja);
        }

        public void KreirajAccount(object param)
        {

        }
        public bool ProvjeriPolja(object param)
        {
            //validirati polja
            return true;
        }
    }
}
