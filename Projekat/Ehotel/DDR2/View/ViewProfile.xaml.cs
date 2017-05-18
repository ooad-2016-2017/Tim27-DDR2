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
    public sealed partial class ViewProfile : Page
    {
        public ViewProfile()
        {
            this.InitializeComponent();
        }

        private void btnSavePass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GuestPanel), e);
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            txtNew.Visibility = Visibility.Visible;
            CurrentPass.Visibility = Visibility.Visible;
            txtReNew.Visibility = Visibility.Visible;
            labelCurrent.Visibility = Visibility.Visible;
            labelNew.Visibility = Visibility.Visible;
            labelRetype.Visibility = Visibility.Visible;
            btnSavePass.Visibility = Visibility.Visible;
        }
    }
}
