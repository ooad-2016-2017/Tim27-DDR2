using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class NewReservation : Page
    {
        public NewReservation()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBlock2_Copy1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock2_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(payment), e);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnsearchRooms_Click(object sender, RoutedEventArgs e)
        {

        }

        private void numericUpDown_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void numericUpDown_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void numericUpDown_Loaded_2(object sender, RoutedEventArgs e)
        {

        }

        private void numericUpDown_Loaded_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
