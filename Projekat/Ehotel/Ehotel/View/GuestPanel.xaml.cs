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
    public sealed partial class GuestPanel : Page
    {
        public GuestPanel()
        {
            this.InitializeComponent();
        }

        private void btnNewRez_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelRez_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowRez_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewProfile), e);
        }

        private void btnChangeRez_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Prijava), e);
        }
    }
}
