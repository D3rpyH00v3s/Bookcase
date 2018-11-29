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
    public partial class AuthorsCollection : ContentPage
    {
        
        AuthorsCollectionViewModel ViewModel { get; set; }

        public AuthorsCollection()
        {
            InitializeComponent();
            ViewModel = new AuthorsCollectionViewModel(Navigation);
            BindingContext = ViewModel;
        }
    }
}