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
    public partial class MainPage : ContentPage
    {
        MainPageViewModel ViewModel { get; set; }

        public MainPage ()
		{
			InitializeComponent ();
            ViewModel = new MainPageViewModel(Navigation);
            BindingContext = ViewModel;
		}
	}
}