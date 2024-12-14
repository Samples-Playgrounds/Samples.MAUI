using System.ComponentModel;
using Fast.ViewModels;
using Xamarin.Forms;

namespace Fast.Views
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