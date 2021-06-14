using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CollectionViewDemos.ViewModels;

namespace CollectionViewDemos.Views
{
    public partial class HorizontalGridPage : ContentPage
    {
        public HorizontalGridPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
