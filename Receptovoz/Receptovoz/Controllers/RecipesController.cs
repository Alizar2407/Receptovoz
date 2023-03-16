using Microsoft.AspNetCore.Mvc;
using Receptovoz.Interfaces;
using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipes;

        public RecipesController(IRecipeRepository iRecipeRepository)
        {
            this._recipes = iRecipeRepository;
        }

        [Route("/recipes/{id}")]
        public ViewResult RecipeTemplate(int id)
        {
            Recipe recipe = _recipes.getRecipe(id);

            ViewData["Title"] = $"Рецептовоз - {recipe.name}";
            return View(recipe);
        }
    }
}
