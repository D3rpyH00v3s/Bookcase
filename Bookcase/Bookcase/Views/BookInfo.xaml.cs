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
    public partial class BookInfo : TabbedPage
    {
        public BookInfo ()
        {
            InitializeComponent();
        }

        BookInfoViewModel ViewModel { get; set; }
        public BookInfo(BookInfoViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.navigation = Navigation;
            BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}