using DDR2.EHotelBaza.Models;
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
    public sealed partial class Rooms : Page
    {
        public Rooms()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new SobaDbContext())
            {
                RoomListView.ItemsSource = db.Sobe.OrderBy(c => c.Naziv).ToList();
            }
        }
        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewRoom), e);
        }

        private void btnRemoveRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPanel), e);
        }
    }
}
