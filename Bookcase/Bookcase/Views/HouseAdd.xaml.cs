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
    public partial class HouseAdd : ContentPage
    {
        HouseAddViewModel ViewModel { get; set; }

        public HouseAdd()
        {

            ViewModel = new HouseAddViewModel(this);
            BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}