using DDR2.HotelBaza.Models;
using DDR2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace DDR2.ViewModel
{
    public interface INavigationService
    {
        void Navigate(Type page);
    }

    public abstract class MainViewModelBase : INotifyPropertyChanged, INavigationService
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigationService NavigationService { get; set; }

        public void Navigate(Type page)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(page);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
