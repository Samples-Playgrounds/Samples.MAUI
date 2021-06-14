using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CollectionViewDemos.ViewModels;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListPage : ContentPage
    {
        public VerticalListPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
