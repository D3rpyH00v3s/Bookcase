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
    public class AuthorInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public INavigation navigation;
        public Author Author { get; set; }
        public UCollection<Book> Books { get; set; }
        public ICommand Change { get; set; }

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

        public AuthorInfoViewModel(Author author)
        {
            Author = author;
            Books = author.Books;
            Change = new Command(() => navigation.PushAsync(new BooksChange(new BooksChangeViewModel(Author))));
        }
    }
}
