using Bookcase.Models;
using Bookcase.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Bookcase.ViewModels
{
    public class BooksCollectionViewModel : INotifyPropertyChanged
    {
        public UCollection<Book> Items { get; set; }
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        Book selected;
        public Book Selected
        {
            get => selected;
            set
            {
                var temp = value;
                selected = null;
                if (temp != null) navigation.PushAsync(new BookInfo(new BookInfoViewModel(temp)));
                OnPropertyChanged("Selected");
            }
        }

        public List<string> SortOptions { get; set; }

        int sortIndex;
        public int SortIndex
        {
            get => sortIndex;
            set
            {
                sortIndex = value;
                IOrderedEnumerable<Book> result = null;
                switch (sortIndex)
                {
                    case 0:
                        result = Items.OrderBy(u => u.Name);
                        break;
                    case 1:
                        result = Items.OrderBy(u => u.Pages);
                        break;
                    case 2:
                        result = Items.OrderBy(u => u.Year);
                        break;
                    case 3:
                        result = Items.OrderBy(u => u.Isbn);
                        break;
                }
                var temp = new UCollection<Book>();
                foreach (Book book in result)
                    temp.Add(book);
                Items.Clear();
                foreach (Book book in temp)
                    Items.Add(book);
                OnPropertyChanged("Items");
                OnPropertyChanged("SortIndex");
            }
        }

        public ICommand Add { get; set; }
        public BooksCollectionViewModel(INavigation nav)
        {
            navigation = nav;
            SortOptions = new List<string>
            {
                "названию",
                "количеству страниц",
                "году издания",
                "ISBN"
            };

            Items = Catalog.Books;
            SortIndex = 0;
            Add = new Command(() => navigation.PushAsync(new BookAdd(this)));
        }

        public void Addbook(Book book)
        {
            Catalog.AddBook(book);
            SortIndex = sortIndex;
        }
    }
}
