using System;
using System.Collections.Generic;
using System.Text;

namespace Bookcase.Models
{
    static class Catalog
    {
        static public UCollection<Book> Books { get; set; } = new UCollection<Book>();
        static public UCollection<Author> Authors { get; set; } = new UCollection<Author>();
        static public UCollection<House> Houses { get; set; } = new UCollection<House>();

        static Catalog()
        {
            House house = new House("Азбука", "Москва");
            Book book = new Book("451 градус по Фаренгейту", "978-5-699-91251-3",174, new string[] { }, 1953, house);
            Author author = new Author("Рэй Бредберри", new DateTime(1920, 08, 22));
            book.Add(author);
            AddBook(book);

            house = new House("АСТ", "Москва");
            book = new Book("1922", "978-5-17-086373-0", 180, new string[] { }, 2010, house);
            author = new Author("Стивен Кинг", new DateTime(1947, 9, 21));
            book.Add(author);
            AddBook(book);
        }

        public static void AddBook(Book book)
        {
            Books.Add(book);
            foreach (Author author in book.Authors)
                if (!Authors.Contains(author)) AddAuthor(author);
            if (!Houses.Contains(book.House)) AddHouse(book.House);
        }

        public static void AddAuthor(Author author)
        {
            Authors.Add(author);
            foreach (Book book in author.Books)
                if (!Books.Contains(book)) AddBook(book);
        }

        public static void AddHouse(House house)
        {
            Houses.Add(house);
            foreach (Book book in house.Books)
                if (!Books.Contains(book)) AddBook(book);
        }
    }
}
