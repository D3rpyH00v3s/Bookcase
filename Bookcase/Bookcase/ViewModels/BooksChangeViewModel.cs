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
    public class BooksChangeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public INavigation navigation;
        public UCollection<Book> Books { get; set; }

        Author author;
        public Book Selected
        {
            get => book;
            set
            {
                book = null;
                var temp = value;
                if (temp != null)
                    temp.Have = !temp.Have;
                OnPropertyChanged("Selected");
            }
        }

        Book book;
        public ICommand Apply { get; set; }

        public BooksChangeViewModel(Author a)
        {
            author = a;
            Books = Catalog.Books;
            foreach (var book in Catalog.Books)
            {
                if (author.Books.Contains(book))
                    book.Have = true;
                else book.Have = false;
            }
            Apply = new Command(() =>
            {
                foreach (var book in Catalog.Books)
                {
                    if ((book.Have) && (!author.Books.Contains(book))) author.Add(book);
                    if ((!book.Have) && (author.Books.Contains(book))) author.Books.Remove(book);
                }
                navigation.PopAsync();
            });
        }
    }
}
