using Bookcase.Models;
using Bookcase.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Bookcase.ViewModels
{
    class HousesCollectionViewModel : INotifyPropertyChanged
    {
        public UCollection<House> Items { get; set; }
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        House selected;
        public House Selected
        {
            get => selected;
            set
            {
                var temp = value;
                selected = null;
                if (temp != null) navigation.PushAsync(new HouseInfo(new HouseInfoViewModel(temp)));
                OnPropertyChanged("Selected");
            }
        }
        public ICommand Add { get; set; }
        public HousesCollectionViewModel(INavigation nav)
        {
            navigation = nav;
            Items = Catalog.Houses;
            Add = new Command(() =>
            {
                navigation.PushAsync(new HouseAdd());
                OnPropertyChanged("Items");
            });
        }
    }
}
