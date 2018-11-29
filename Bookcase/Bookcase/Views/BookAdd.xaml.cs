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
    public partial class BookAdd : TabbedPage
    {
        BookAddViewModel ViewModel { get; set; }

        public BookAdd ()
        {
            InitializeComponent();
        }

        public BookAdd(BooksCollectionViewModel model)
        {

            ViewModel = new BookAddViewModel(this,model);
            BindingContext = ViewModel;
            InitializeComponent();
        }

    }
}