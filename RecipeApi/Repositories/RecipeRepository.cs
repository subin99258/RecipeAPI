using RecipeApi.Data;
using RecipeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.Find(id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }
    }
}
