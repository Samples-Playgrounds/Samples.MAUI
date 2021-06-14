using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CollectionViewDemos.ViewModels;

namespace CollectionViewDemos.Views
{
    public partial class EmptyViewNullPage : ContentPage
    {
        public EmptyViewNullPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
