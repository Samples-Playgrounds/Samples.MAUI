namespace RecipeFinder.Models;

public class Recipe
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> Instructions { get; set; }
    public bool IsFavorite { get; set; }

    public Recipe()
    {
        Id = Guid.NewGuid().ToString();
        Ingredients = new List<string>();
        Instructions = new List<string>();
    }
}

