using DDR2.HotelBaza.Models;
using DDR2.Model;
using DDR2.ViewModel;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class Reception : Page
    {
        public Reception()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            DataContext = (ReceptionVM)e.Parameter;
        }
        private async void odcekirajBtn_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (var db = new HotelDbContext())
            {
                Rezervacija rez = (Rezervacija)ReservationsListView.ItemFromContainer(dep);
                if (!rez.IsCheckedIn)
                {
                    var dialog = new MessageDialog("You are not checked in!");
                    dialog.Title = "Error";
                    await dialog.ShowAsync();
                }
                else rez.IsCheckedOut = true;
                db.Entry(rez).State = EntityState.Modified;
                db.SaveChanges();
                ReservationsListView.ItemsSource = db.Rezervacije.OrderBy(c => c.Cijena).ToList();
            }
        }

        private void cekirajBtn_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (var db = new HotelDbContext())
            {
                Rezervacija rez = (Rezervacija)ReservationsListView.ItemFromContainer(dep);
                rez.IsCheckedIn = true;
                db.Entry(rez).State = EntityState.Modified;
                db.SaveChanges();
                ReservationsListView.ItemsSource = db.Rezervacije.OrderBy(c => c.Cijena).ToList();
            }
        }

        private void detailsBtn_Click(object sender, RoutedEventArgs e)
        {
               //ovo bi moralo preko binding :/
        }
    }
}
