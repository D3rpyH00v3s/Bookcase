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
    public partial class AuthorInfo : TabbedPage
    {
        public AuthorInfo()
        {
            InitializeComponent();
        }

        AuthorInfoViewModel ViewModel { get; set; }
        public AuthorInfo(AuthorInfoViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.navigation = Navigation;
            BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}