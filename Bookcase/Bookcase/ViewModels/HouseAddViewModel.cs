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

    class HouseAddViewModel : INotifyPropertyChanged
    {
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public string Name { get; set; }
        public string City { get; set; }

        public ICommand Apply { get; set; }
        public ICommand Add { get; set; }

        public HouseAddViewModel(HouseAdd houseAdd)
        {
            navigation = houseAdd.Navigation;
            Name = "";
            City = "";
            Apply = new Command(() =>   
            {
                if (Name == "")
                {
                    houseAdd.DisplayAlert("Внимание!", "Поле \"имя\" не заполнено.", "ОК");
                    return;
                }
                if (City == "")
                {
                    houseAdd.DisplayAlert("Внимание!", "Поле \"город\" не заполнено.", "ОК");
                    return;
                }
                House house = new House(Name, City);
                Catalog.AddHouse(house);
                navigation.PopAsync();
            });

        }
    }
}