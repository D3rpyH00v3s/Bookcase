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
    class AuthorsCollectionViewModel : INotifyPropertyChanged
    {
        public UCollection<Author> Items { get; set; }
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        Author selected;
        public Author Selected
        {
            get => selected;
            set
            {
                var temp = value;
                selected = null;
                if (temp != null) navigation.PushAsync(new AuthorInfo(new AuthorInfoViewModel(temp)));
                OnPropertyChanged("Selected");
            }
        }

        public ICommand Add { get; set; }
        public AuthorsCollectionViewModel(INavigation nav)
        {
            navigation = nav;
            Items = Catalog.Authors;
            Add = new Command(() =>
            {
                navigation.PushAsync(new AuthorAdd());
                OnPropertyChanged("Items");
            });
        }
    }
}
