using DDR2.HotelBaza.Models;
using DDR2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DDR2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddStuff : Page
    {
        public AddStuff()
        {
            this.InitializeComponent();
        }

        private void btnNewAcc_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new HotelDbContext())
            {
                if (posaoSelector.SelectedItem.ToString() == "Receptionist")
                {
                    var contact = new Recepcionar
                    {
                        Ime = txtFname.Text,
                        Prezime = txtLname.Text,
                        Telefon = txtMobile.Text,
                        Adresa = txtAddress.Text,
                        Drzava = CountrySelector.SelectedItem.ToString(),
                        Grad = txtCity.Text,
                        Email = txtEmail.Text,
                        Jmbg = txtJmbg.Text,
                        // Dat_rodjenja =datumRodjenja,
                        // Dat_zaposlenja=datumZaposlenja,
                        Username = txtUsername.Text,
                        Password = txtPassword.Password,
                        Plata = Convert.ToDouble(txtSalary.Text),
                        //Moramo spol dodati al svakako nam je sve pokvareno
                    };
                    db.Recepcionari.Add(contact);
                }
                else if(posaoSelector.SelectedItem.ToString() == "Maid")
                {
                    var contact = new Sobarica
                    {
                        Ime = txtFname.Text,
                        Prezime = txtLname.Text,
                        Telefon = txtMobile.Text,
                        Adresa = txtAddress.Text,
                        Drzava = CountrySelector.SelectedItem.ToString(),
                        Grad = txtCity.Text,
                        Email = txtEmail.Text,
                        Jmbg = txtJmbg.Text,
                        // Dat_rodjenja =datumRodjenja,
                        // Dat_zaposlenja=datumZaposlenja,
                        Username = txtUsername.Text,
                        Password = txtPassword.Password,
                        Plata = Convert.ToDouble(txtSalary.Text),
                        //Moramo spol dodati al svakako nam je sve pokvareno
                    };
                    db.Sobarice.Add(contact);
                }
                db.SaveChanges();

                //reset polja za unos
                txtSalary.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtLname.Text = string.Empty;
                txtJmbg.Text = string.Empty;
                txtFname.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCpassword.Password = string.Empty;
                txtCpassword.PlaceholderText = "Confirm your password";
                txtPassword.Password = string.Empty;
                txtPassword.PlaceholderText = "Password";
                txtCity.Text = string.Empty;
                txtAddress.Text = string.Empty;
                CountrySelector.PlaceholderText = string.Empty;
                posaoSelector.PlaceholderText = string.Empty;
                txtFname.Text = string.Empty;
                male.IsChecked = false;
                female.IsChecked = false;
            }
        }
    }
}
