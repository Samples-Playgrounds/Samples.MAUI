using System;
using System.Collections.Generic;
using System.ComponentModel;
using Fast.Models;
using Fast.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fast.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();
			BindingContext = new NewItemViewModel();
		}
	}
}