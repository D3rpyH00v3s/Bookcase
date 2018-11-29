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
    public class BookInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public INavigation navigation;
        public Book Book { get; set; }
        public UCollection<Author> Authors { get; set; }
        public ICommand Change { get; set; } 

        Author author;
        public Author Selected
        {
            get => author;
            set
            {
                author = null;
                var temp = value;
                if (temp != null) navigation.PushAsync(new AuthorInfo(new AuthorInfoViewModel(temp)));
                OnPropertyChanged("Selected");
            }
        }

        public BookInfoViewModel(Book book)
        {
            Book = book;
            Authors = book.Authors;
            Change = new Command(() => navigation.PushAsync(new AuthorsChange(new AuthorsChangeViewModel(Book))));
        }
    }
}
