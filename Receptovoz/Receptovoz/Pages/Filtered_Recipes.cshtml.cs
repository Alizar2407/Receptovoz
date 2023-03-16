using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receptovoz.Interfaces;
using Receptovoz.Models;

namespace Receptovoz.Pages
{
    public class Filtered_RecipesModel : PageModel
    {
        private readonly IRecipeRepository _recipes;
        public List<Recipe> FilteredRecipes { get; set; }

        public Filtered_RecipesModel(IRecipeRepository iRecipeRepository)
        {
            this._recipes = iRecipeRepository;
            FilteredRecipes = _recipes.allRecipes.ToList();
        }

        [BindProperty]
        public string RecipeName { get; set; }

        [BindProperty]
        public string SearchTags { get; set; }

        public void OnPost()
        {
            string parsedRecipeName = string.Empty;
            if (RecipeName != null)
                parsedRecipeName = RecipeName.Trim().ToLower();

            List<string> parsedSearchTags = new List<string>();
            if (SearchTags != null)
                foreach (string searchTag in SearchTags.Split(";"))
                    parsedSearchTags.Add(searchTag.Trim().ToLower());

            IEnumerable<Recipe> allRecipes = _recipes.allRecipes;
            FilteredRecipes = new List<Recipe>();
            foreach (Recipe recipe in allRecipes)
            {
                if (parsedRecipeName == string.Empty || recipe.name.ToLower().Contains(parsedRecipeName))
                {
                    bool recipeHasTagFlag = parsedSearchTags.Count == 0;

                    foreach (string parsedSearchTag in parsedSearchTags)
                        foreach(string recipeSearchTag in recipe.searchTags)
                            if (recipeSearchTag.Contains(parsedSearchTag))
                                recipeHasTagFlag = true;

                    if (recipeHasTagFlag)
                        FilteredRecipes.Add(recipe);
                }
            }
        }
    }
}
