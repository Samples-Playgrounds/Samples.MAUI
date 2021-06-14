using CollectionViewDemos.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListVariableSizeItemsPage : ContentPage
    {
        public VerticalListVariableSizeItemsPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
