using peruscanner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace peruscanner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}