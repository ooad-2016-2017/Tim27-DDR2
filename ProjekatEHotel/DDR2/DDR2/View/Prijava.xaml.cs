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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DDR2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        public Prijava()
        {
            this.InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text=="admin" && txtPassword.Password=="admin")
            this.Frame.Navigate(typeof(AdminPanel), e);
            if (txtEmail.Text == "recepcionar" && txtPassword.Password == "recepcionar")
                this.Frame.Navigate(typeof(Reception), e);
            if (txtEmail.Text == "gost" && txtPassword.Password == "gost")
                this.Frame.Navigate(typeof(GuestPanel), e);
            if (txtEmail.Text == "sobarica" && txtPassword.Password == "sobarica")
                this.Frame.Navigate(typeof(RoomCleaning), e);
        }
        private void btnNewAcc_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewAccount), e);
        }
    }
}

