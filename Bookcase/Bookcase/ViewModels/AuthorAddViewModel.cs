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

    class AuthorAddViewModel : INotifyPropertyChanged
    {
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public UCollection<Book> Books { get; set; }

        public UCollection<Book> AllBooks { get; set; }

        public Book Selected
        {
            get => null;
            set
            {
                if (value != null) value.Have = !value.Have;
                OnPropertyChanged("Selected");
            }
        }

        public ICommand Apply { get; set; }
        public ICommand Add { get; set; }

        public AuthorAddViewModel(AuthorAdd authorAdd)
        {
            navigation = authorAdd.Navigation;
            Name = "";

            AllBooks = Catalog.Books;
            foreach (var book in AllBooks)
                book.Have = false;
            Books = new UCollection<Book>();
            Apply = new Command(() =>
            {
                bool flag = true;
                if (Name == "")
                {
                    authorAdd.DisplayAlert("Внимание!", "Поле \"имя\" не заполнено.", "ОК");
                    flag = false;
                }
                if(Birthday>DateTime.Now)
                {
                    authorAdd.DisplayAlert("Внимание!", "Выбрана некорректная дата.", "ОК");
                    flag = false;
                }
                if (!flag) return;
                Author author = new Author(Name, Birthday);
                foreach (var book in Catalog.Books)
                    if (book.Have) author.Add(book);
                Catalog.AddAuthor(author);
                navigation.PopAsync();
            });

        }
    }
}