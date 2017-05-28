﻿using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using static DDR2.Model.Osoba;

namespace DDR2.ViewModel
{
    public class NewAccountVM : MainViewModelBase
    {
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string Grad { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Username { get; set; } = "";
        string password = "";
        string confirmPassword = "";
        public string Password { get { return password; } set { password = Encryptor.MD5Hash(value); } }
        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = Encryptor.MD5Hash(value); } }
        public string Drzava { get; set; } = "";
        public gender Spol { get; set; }
        public List<string> Drzave { get; set; }
        public DateTime DatumRodjenja { get; set; } = DateTime.Now;
        Gost NoviGost;
        public ICommand Create { get; set; }
        public INavigationService NavigationService { get; set; }

        public NewAccountVM()
        {
            NavigationService = new NavigationService();
            Create = new RelayCommand<object>(KreirajAccount,ProvjeriPolja);
            PopuniDrzave();
        }

        public void PopuniDrzave()
        {
            Drzave = new List<string>  {"Albania","Andorra","Armenia","Austria","Azerbaijan",
                                        "Belarus","Belgium","Bosnia and Herzegovina","Bulgaria",
                                        "Croatia","Cyprus","Czech Republic","Denmark","Estonia",
                                        "Finland","France","Georgia","Germany","Greece",
                                        "Hungary","Iceland","Ireland","Italy","Kazakhstan","Kosovo",
                                        "Latvia","Liechtenstein","Lithuania","Luxembourg",
                                        "Macedonia","Malta","Moldova","Monaco","Montenegro",
                                        "Netherlands","Norway","Poland","Portugal","Romania","Russia",
                                        "San Marino","Serbia","Slovakia","Slovenia","Spain","Sweden",
                                        "Switzerland","Turkey","Ukraine","United Kingdom"};
        }

        public async void KreirajAccount(object param)
        {
            NoviGost = new Gost(Username, Password, Ime, Prezime, Adresa, Drzava, Email, Grad, Telefon, DatumRodjenja, Spol);
            using (var db = new HotelDbContext())
            {
                db.Gosti.Add(NoviGost);
                db.Korisnici.Add(NoviGost);
                db.SaveChanges();
                var dialog = new MessageDialog("Account created!");
                await dialog.ShowAsync();
            }
        }

        public bool ProvjeriPolja(object param)
        {
            //validirati polja
            if (Password != ConfirmPassword) return false;
            return true;
        }
    }
}