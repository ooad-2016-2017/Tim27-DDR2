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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DDR2.View
{
    public sealed partial class numericUpDown : UserControl
    {
        int brojac = 0;
        public numericUpDown()
        {
            this.InitializeComponent();
            broj.Text = "0";
            broj.IsReadOnly = true;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            brojac++;
            broj.Text = brojac.ToString();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            brojac--;
            if(brojac<=0) brojac=0;
            broj.Text = brojac.ToString();
        }
    }
}
