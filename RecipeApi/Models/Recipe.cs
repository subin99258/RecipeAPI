namespace RecipeApi.Models
{
    public class Recipe
    {
        public int recipe_id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
