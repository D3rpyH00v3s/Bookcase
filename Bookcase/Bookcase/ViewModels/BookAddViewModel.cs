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
    public class MyString : Item
    {
        public string Field { get; set; }
        public MyString(string field)
        {
            Field = field;
        }
    }

    class BookAddViewModel : INotifyPropertyChanged
    {
        INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public string Name { get; set; }
        public int Pages { get; set; }
        public string Isbn { get; set; }
        public UCollection<MyString> Tags { get; set; }
        public int Year { get; set; }
        public UCollection<Author> Authors { get; set; }
        public House House { get; set; }

        public UCollection<Author> AllAuthors { get; set; }
        public List<House> Houses { get; set; }

        public Author Selected
        {
            get => null;
            set
            {
                if(value!=null) value.Have = !value.Have;
                OnPropertyChanged("Selected");
            }
        }

        public string NewTag { get; set; }

        public ICommand Apply { get; set; }
        public ICommand Add { get; set; }

        public BookAddViewModel(BookAdd bookAdd,BooksCollectionViewModel model)
        { 
            navigation = bookAdd.Navigation;
            Name = "";
            Isbn = "";
            Houses = new List<House>();
            foreach (House house in Catalog.Houses)
                Houses.Add(house);

            AllAuthors = Catalog.Authors;
            foreach (var author in AllAuthors)
                author.Have = false;
            Authors = new UCollection<Author>();
            Tags = new UCollection<MyString>();
            Add = new Command(() =>
            {
                if (NewTag == "") return;
                Tags.Add(new MyString(NewTag));
                OnPropertyChanged("Tags");
                NewTag = "";
                OnPropertyChanged("NewTag");
            });
            Apply = new Command(() =>
            {
                if (Name == "")
                {
                    bookAdd.DisplayAlert("Внимание!", "Поле \"название\" не заполнено.", "ОК");
                    return;
                }
                if (Isbn == "")
                {
                    bookAdd.DisplayAlert("Внимание!", "Поле \"Isbn\" не заполнено.", "ОК");
                    return;
                }
                if (Year < 1000)
                {
                    bookAdd.DisplayAlert("Внимание!", "Поле \"год\" заполнено некорректно.", "ОК");
                    return;
                }
                if (Pages <= 0)
                {
                    bookAdd.DisplayAlert("Внимание!", "Поле \"количество страниц\" не заполнено.", "ОК");
                    return;
                }
                if (House == null)
                {
                    bookAdd.DisplayAlert("Внимание!", "Не выбрано издательство.", "ОК");
                    return;
                }
                string[] tags = new string[Tags.Count];
                int i = 0;
                foreach(MyString tag in Tags)
                {
                    tags[i] = tag.Field;
                    i++;
                }
                Book book = new Book(Name, Isbn, Pages, tags, Year, House);
                foreach (var author in Catalog.Authors)
                    if (author.Have) book.Add(author);
                model.Addbook(book);
                navigation.PopAsync();
            });
            
        }
    }
}