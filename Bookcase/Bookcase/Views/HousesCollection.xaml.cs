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
	public partial class HousesCollection : ContentPage
	{
        HousesCollectionViewModel ViewModel { get; set; }

        public HousesCollection()
        {
            InitializeComponent();
            ViewModel = new HousesCollectionViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}