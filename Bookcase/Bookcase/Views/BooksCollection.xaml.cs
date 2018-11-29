using Bookcase.Models;
using Bookcase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookcase.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BooksCollection : ContentPage
	{
        BooksCollectionViewModel ViewModel { get; set; }

        public BooksCollection ()
		{
			InitializeComponent ();
            ViewModel = new BooksCollectionViewModel(Navigation);
            BindingContext = ViewModel;
		}
	}
}