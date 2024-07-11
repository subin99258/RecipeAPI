using RecipeApi.Models;
using System.Collections.Generic;

namespace RecipeApi.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
    }
}
