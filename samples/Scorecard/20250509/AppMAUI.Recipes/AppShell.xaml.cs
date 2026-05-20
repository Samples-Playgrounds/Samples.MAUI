using RecipeFinder.Views;

namespace AppMAUI.Recipes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
	}
}
