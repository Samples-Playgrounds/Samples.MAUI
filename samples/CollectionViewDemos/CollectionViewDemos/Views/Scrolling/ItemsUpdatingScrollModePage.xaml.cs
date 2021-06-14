using CollectionViewDemos.Controls;
using CollectionViewDemos.ViewModels;
using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace CollectionViewDemos.Views
{
    public partial class ItemsUpdatingScrollModePage : ContentPage
    {
        public ItemsUpdatingScrollModePage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModelWithDelay();
        }

        void OnItemsUpdatingScrollModeChanged(object sender, EventArgs e)
        {
            collectionView.ItemsUpdatingScrollMode = (ItemsUpdatingScrollMode)(sender as EnumPicker).SelectedItem;
        }
    }
}
