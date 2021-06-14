using CollectionViewDemos.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListEmptyGroupsPage : ContentPage
    {
        public VerticalListEmptyGroupsPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel(true);
        }
    }
}
