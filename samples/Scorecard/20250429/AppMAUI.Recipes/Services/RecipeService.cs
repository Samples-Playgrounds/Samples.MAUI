using RecipeFinder.Models;

namespace RecipeFinder.Services;

public class RecipeService
{
    private List<Recipe> _recipes;

    public RecipeService()
    {
        _recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Pancakes",
                    Description = "Fluffy breakfast pancakes",
                    Category = "Breakfast",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/10/27/22/12/pancake-1776646_1280.jpg",
                    Ingredients = new List<string> { "2 cups flour", "2 eggs", "1 cup milk", "1 tbsp sugar", "1 tsp baking powder" },
                    Instructions = new List<string> { "Mix dry ingredients", "Add wet ingredients", "Cook on griddle" }
                },
                new Recipe
                {
                    Name = "Spaghetti Carbonara",
                    Description = "Classic Italian pasta dish",
                    Category = "Dinner",
                    ImageUrl = "https://cdn.pixabay.com/photo/2021/03/03/14/40/pasta-6065333_1280.jpg",
                    Ingredients = new List<string> { "Spaghetti", "Eggs", "Parmesan", "Pancetta", "Black pepper" },
                    Instructions = new List<string> { "Cook pasta", "Fry pancetta", "Mix eggs and cheese", "Combine all ingredients" }
                },
                new Recipe
                {
                    Name = "Caesar Salad",
                    Description = "Fresh and crispy salad",
                    Category = "Lunch",
                    ImageUrl = "https://cdn.pixabay.com/photo/2014/11/05/16/06/salad-518034_1280.jpg",
                    Ingredients = new List<string> { "Romaine lettuce", "Croutons", "Parmesan", "Caesar dressing" },
                    Instructions = new List<string> { "Chop lettuce", "Add croutons and cheese", "Toss with dressing" }
                },
                new Recipe
                {
                    Name = "Chocolate Chip Cookies",
                    Description = "Classic homemade cookies",
                    Category = "Dessert",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/11/17/22/53/biscuits-1832917_1280.jpg",
                    Ingredients = new List<string> { "Flour", "Butter", "Sugar", "Chocolate chips", "Eggs" },
                    Instructions = new List<string> { "Cream butter and sugar", "Add eggs", "Mix in dry ingredients", "Fold in chocolate chips", "Bake at 375°F" }
                },
                new Recipe
                {
                    Name = "Fruit Smoothie",
                    Description = "Refreshing fruit smoothie",
                    Category = "Beverage",
                    ImageUrl = "https://cdn.pixabay.com/photo/2018/09/23/09/31/smoothie-3697014_1280.jpg",
                    Ingredients = new List<string> { "Banana", "Strawberries", "Yogurt", "Honey", "Ice" },
                    Instructions = new List<string> { "Add all ingredients to blender", "Blend until smooth", "Serve immediately" }
                }
            };
    }

    public List<Recipe> GetAllRecipes()
    {
        return _recipes;
    }

    public List<Recipe> GetRecipesByCategory(string category)
    {
        return _recipes.Where(r => r.Category == category).ToList();
    }

    public Recipe GetRecipeById(string id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id);
    }

    public List<string> GetCategories()
    {
        return _recipes.Select(r => r.Category).Distinct().ToList();
    }

    public void ToggleFavorite(string id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        if (recipe != null)
        {
            recipe.IsFavorite = !recipe.IsFavorite;
        }
    }

    public List<Recipe> GetFavorites()
    {
        return _recipes.Where(r => r.IsFavorite).ToList();
    }
}
