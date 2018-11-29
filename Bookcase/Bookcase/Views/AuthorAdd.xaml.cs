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
    public partial class AuthorAdd : TabbedPage
    {
        AuthorAddViewModel ViewModel { get; set; }

        public AuthorAdd()
        {

            ViewModel = new AuthorAddViewModel(this);
            BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}