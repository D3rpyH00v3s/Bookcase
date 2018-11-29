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
    public class AuthorsChangeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public INavigation navigation;
        public UCollection<Author> Authors { get; set; }

        Author author;
        public Author Selected
        {
            get => author;
            set
            {
                author = null;
                var temp = value;
                if (temp != null)
                    temp.Have = !temp.Have;
                OnPropertyChanged("Selected");               
            }
        }

        Book book;
        public ICommand Apply { get; set; }

        public AuthorsChangeViewModel(Book b)
        {
            book = b;
            Authors = Catalog.Authors;
            foreach (var author in Catalog.Authors)
            {
                if (book.Authors.Contains(author))
                    author.Have = true;
                else author.Have = false;
            }
            Apply = new Command(() =>
            {
                foreach(var author in Catalog.Authors)
                {
                    if ((author.Have) && (!book.Authors.Contains(author))) book.Add(author);
                    if ((!author.Have) && (book.Authors.Contains(author))) book.Authors.Remove(author);
                }
                navigation.PopAsync();
            });
        }
    }
}
