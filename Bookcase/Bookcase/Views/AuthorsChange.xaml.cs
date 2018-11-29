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
	public partial class AuthorsChange : ContentPage
	{
		public AuthorsChange ()
		{
			InitializeComponent ();
		}

        AuthorsChangeViewModel ViewModel { get; set; }
        public AuthorsChange(AuthorsChangeViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.navigation = Navigation;
            BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}