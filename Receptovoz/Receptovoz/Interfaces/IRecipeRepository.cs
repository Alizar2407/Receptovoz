using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Interfaces
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> allRecipes { get; }

        Recipe getRecipe(int id);
        Recipe getRecipe(string name);
    }
}
