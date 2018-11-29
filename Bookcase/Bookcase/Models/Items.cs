using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Bookcase.ViewModels;

namespace Bookcase.Models
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));


        public string Name { get; set; }
        bool have;
        public bool Have { get => have; set
            {
                have = value;
                OnPropertyChanged("Have");
            } }
    }

    public class Book : Item
    {
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public string[] Tags { get; set; }
        public int Year { get; set; }
        public UCollection<Author> Authors { get; set; }
        House house;
        public House House
        {
            get => house;
            set
            {
                house = value;
                if (!house.Books.Contains(this)) house.Books.Add(this);
            }
        }

        public Book(string name, string isbn, int pages, string[] tags, int year, House house)
        {
            Name = name;
            Isbn = isbn;
            Pages = pages;
            Tags = tags;
            Year = year;
            Authors = new UCollection<Author>();
            House = house;
        }

        public void Add(Author author)
        {
            if (Authors.Contains(author)) return;
            Authors.Add(author);
            if (!author.Books.Contains(this))
                author.Add(this);
        }

    }

    public class Author : Item
    {
        public DateTime Birthday { get; set; }
        public UCollection<Book> Books { get; set; }
        public Author(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
            Books = new UCollection<Book>();
        }

        public void Add(Book book)
        {
            if (Books.Contains(book)) return;
            Books.Add(book);
            if (!book.Authors.Contains(this))
                book.Add(this);
        }
    }

    public class House : Item
    {
        public string City { get; set; }
        public UCollection<Book> Books { get; set; }
        public House(string name, string city)
        {
            Name = name;
            City = city;
            Books = new UCollection<Book>();
        }
    }
}
