using DDR2.Helper;
using DDR2.Model;
using DDR2.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DDR2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewAccount : Page
    {
        public NewAccount()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        IMobileServiceTable<GostTabela> userTableObj = App.MobileService.GetTable<GostTabela>();
        private void btnNewAcc_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                GostTabela obj = new GostTabela();
                obj.ime = txtFname.Text;
                obj.prezime = txtLname.Text;
                obj.grad = txtGrad.Text;
                obj.adresa = txtAddress.Text;
                obj.email = txtEmail.Text;
                obj.telefon = txtTelefon.Text;
                obj.username = txtUsername.Text;
                obj.password = txtPassword.Password;
                obj.drzava = (string)cdrzave.SelectedValue;
                obj.dat_rodjenja = dpRodjenje.Date.ToString();
                userTableObj.InsertAsync(obj);
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
