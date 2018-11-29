using Bookcase.Models;
using Bookcase.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bookcase.ViewModels
{
    class MainPageViewModel
    {
        public ICommand Books { get; set; }
        public ICommand Authors { get; set; } 
        public ICommand Houses { get; set; } 
        INavigation navigation;

        public MainPageViewModel(INavigation nav)
        {
            navigation = nav;
            Books = new Command(() => navigation.PushAsync(new BooksCollection()));
            Authors = new Command(() => navigation.PushAsync(new AuthorsCollection()));
            Houses = new Command(() => navigation.PushAsync(new HousesCollection()));

        }
    }
}
