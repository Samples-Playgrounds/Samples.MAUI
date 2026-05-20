using RecipeFinder.Models;
using RecipeFinder.Services;

namespace RecipeFinder.Views;

public partial class RecipeDetailPage : ContentPage
{
    private Recipe _recipe;
    private RecipeService _recipeService;
    
    public RecipeDetailPage(Recipe recipe, RecipeService recipeService)
    {
        InitializeComponent();
        _recipe = recipe;
        _recipeService = recipeService;
        
        // Set recipe details
        RecipeImage.Source = _recipe.ImageUrl;
        RecipeName.Text = _recipe.Name;
        RecipeCategory.Text = _recipe.Category;
        RecipeDescription.Text = _recipe.Description;
        
        // Set favorite button
        UpdateFavoriteButton();
        
        // Set collections
        IngredientsCollection.ItemsSource = _recipe.Ingredients;
        
        // Create numbered instructions
        var numberedInstructions = _recipe.Instructions
            .Select((instruction, index) => $"{index + 1}. {instruction}")
            .ToList();
        InstructionsCollection.ItemsSource = numberedInstructions;
    }
    
    private void UpdateFavoriteButton()
    {
        FavoriteButton.Source = _recipe.IsFavorite ? "star_filled.png" : "star_empty.png";
    }

    private void FavoriteButton_Clicked(object sender, EventArgs e)
    {
        _recipeService.ToggleFavorite(_recipe.Id);
        UpdateFavoriteButton();
    }
}
