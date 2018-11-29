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
    public class HouseInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public INavigation navigation;
        public House House { get; set; }
        public UCollection<Book> Books { get; set; }

        Book book;
        public Book Selected
        {
            get => book;
            set
            {
                book = null;
                var temp = value;
                if (temp != null) navigation.PushAsync(new BookInfo(new BookInfoViewModel(temp)));
                OnPropertyChanged("Selected");
            }
        }

        public HouseInfoViewModel(House house)
        {
            House = house;
            Books = house.Books;
        }
    }
}
