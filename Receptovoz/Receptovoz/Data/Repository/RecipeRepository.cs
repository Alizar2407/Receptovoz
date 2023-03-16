using Receptovoz.Interfaces;
using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDBContent appDBContent;

        public RecipeRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Recipe> allRecipes => this.appDBContent.Recipe.ToArray();

        public Recipe getRecipe(int id) => this.appDBContent.Recipe.FirstOrDefault(r => r.id == id);
        public Recipe getRecipe(string name) => this.appDBContent.Recipe.FirstOrDefault(r => r.name == name);
    }
}
