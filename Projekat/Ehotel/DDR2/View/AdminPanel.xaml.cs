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
    public sealed partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            this.InitializeComponent();
        }

        private void btnRez_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminReservations), e);
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Staff), e);
        }

        private void btnRooms_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rooms), e);
        }

        private void btnGuests_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Guests), e);
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Statistics), e);
        }

        private void btnMonthly_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MonthlyReport), e);
        }

        private void btnProfile_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewProfile), e);
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Prijava), e);
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
