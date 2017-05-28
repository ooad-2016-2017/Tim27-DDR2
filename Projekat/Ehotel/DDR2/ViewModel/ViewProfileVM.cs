﻿using DDR2.Helper;
using DDR2.HotelBaza.Models;
using DDR2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using static DDR2.Model.Osoba;

namespace DDR2.ViewModel
{
    class ViewProfileVM : MainViewModelBase
    {
        public string WelcomePoruka { get; set; } = "Welcome";
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Username { get; set; }
        string currentpassword;
        public string NewPassword { get; set; } //ne moramo novi i potvrdu enkriptovati jer ce oni biti enkriptovani u seteru korisnika
        public string ConfirmPassword { get; set; } //enkriptujemo samo trenutni pass jer se on kuca i poredi sa enkriptovanim jel isti
        public string CurrentPassword { get { return currentpassword; } set { currentpassword = Encryptor.MD5Hash(value); } }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public gender Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<string> Drzave { get; set; }
        public AdminPanelVM AdminParent { get; set; }
        public ICommand SavePassword { get; set; }
        public ICommand SaveEverythingElse { get; set; }

        public ViewProfileVM(AdminPanelVM parent)
        {
            AdminParent = parent;
            ProslijediPoruku();
            Drzave = NewAccountVM.PopuniDrzave(Drzave);
            InicijalizirajPodatke();
            SavePassword = new RelayCommand<object>(PromjenaPass, parametar => true);
            SaveEverythingElse = new RelayCommand<object>(PromjenaOstalo, parametar => true);
        }

        public void InicijalizirajPodatke()
        {
            using (var db = new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == AdminParent.Parent.Username && Encryptor.MD5Hash(kor.Password) == AdminParent.Parent.Password);
                Ime = korisnik.Ime;
                Prezime = korisnik.Prezime;
                Adresa = korisnik.Adresa;
                Grad = korisnik.Grad;
                Spol = korisnik.Spol_osobe;
                Username = korisnik.Username;
                Telefon = korisnik.Telefon;
                Email = korisnik.Email;
                DatumRodjenja = korisnik.Dat_rodjenja;
                Drzava = korisnik.Drzava;
            }
        }

        public async void PromjenaOstalo(object p)
        {
            using(var db=new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == AdminParent.Parent.Username && Encryptor.MD5Hash(kor.Password) == AdminParent.Parent.Password);
                korisnik.Ime = Ime;
                korisnik.Prezime = Prezime;
                korisnik.Adresa = Adresa;
                korisnik.Grad = Grad;
                korisnik.Spol_osobe = Spol;
                korisnik.Username = Username;
                korisnik.Telefon = Telefon;
                korisnik.Email = Email;
                korisnik.Dat_rodjenja = DatumRodjenja;
                korisnik.Drzava = Drzava;

                db.SaveChanges();
                var dialog = new MessageDialog("Changes saved!");
                await dialog.ShowAsync();
            }
        }

        public async void PromjenaPass(object p)
        {
            using (var db = new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == AdminParent.Parent.Username && Encryptor.MD5Hash(kor.Password) == AdminParent.Parent.Password);

                if (Encryptor.MD5Hash(korisnik.Password) != CurrentPassword)
                {
                    var dialog = new MessageDialog("Incorrect password!\nPlease, re-enter your password.");
                    dialog.Title = "Error";
                    await dialog.ShowAsync();
                }
                else
                {
                    if (NewPassword != ConfirmPassword)
                    {
                        var dialog = new MessageDialog("Passwords don't match!\nPlease, re-enter your new password.");
                        dialog.Title = "Error";
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        korisnik.Password = NewPassword;

                        db.SaveChanges();
                        var dialog = new MessageDialog("Your password has been changed successfully!");
                        await dialog.ShowAsync();
                        //cim promjeni password odlogujemo ga
                        AdminParent.Parent.NavigationService.GoBack();
                    }
                }
            }
        }

        public void ProslijediPoruku()
        {
            using (var db = new HotelDbContext())
            {
                var korisnik = db.Korisnici.FirstOrDefault(kor => kor.Username == AdminParent.Parent.Username && Encryptor.MD5Hash(kor.Password) == AdminParent.Parent.Password);
                WelcomePoruka += " " + korisnik.Ime + " " + korisnik.Prezime;
            }
        }
        
    }
}