using CollectionViewDemos.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListRTLPage : ContentPage
    {
        public VerticalListRTLPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
