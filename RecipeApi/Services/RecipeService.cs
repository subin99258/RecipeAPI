using RecipeApi.Models;
using RecipeApi.Repositories;
using System.Collections.Generic;

namespace RecipeApi.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipeRepository.GetAllRecipes();
        }

        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetRecipeById(id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipeRepository.AddRecipe(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _recipeRepository.UpdateRecipe(recipe);
        }

        public void DeleteRecipe(int id)
        {
            _recipeRepository.DeleteRecipe(id);
        }
    }
}
