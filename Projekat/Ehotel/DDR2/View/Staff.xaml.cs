using DDR2.HotelBaza.Models;
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
    public sealed partial class Staff : Page
    {
        public Staff()
        {
            this.InitializeComponent();
        }

        private void btnAddStuff_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddStuff), e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPanel), e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new HotelDbContext())
            {
                StaffListView.ItemsSource = db.Recepcionari.OrderBy(c => c.Plata).ToList();
                StaffListView2.ItemsSource = db.Sobarice.OrderBy(c => c.Plata).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Dobavljanje objekta iz liste koji je korišten da se popuni red u listview 
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem)) {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;
            using (var db = new HotelDbContext()) {
                db.Recepcionari.Remove((Recepcionar) 
                    StaffListView.ItemFromContainer(dep));
                db.SaveChanges();
                //Refresh liste recepcionara 
                StaffListView.ItemsSource = db.Recepcionari.OrderBy(c => c.Plata).ToList();
            }

        }
    }
}
