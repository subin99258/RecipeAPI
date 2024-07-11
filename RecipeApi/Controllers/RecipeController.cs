using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;
using RecipeApi.Services;
using System.Collections.Generic;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
        {
            return Ok(_recipeService.GetAllRecipes());
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult<Recipe> AddRecipe(Recipe recipe)
        {
            _recipeService.AddRecipe(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.recipe_id }, recipe);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, Recipe recipe)
        {
            if (id != recipe.recipe_id)
            {
                return BadRequest();
            }

            _recipeService.UpdateRecipe(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            _recipeService.DeleteRecipe(id);
            return NoContent();
        }
    }
}
