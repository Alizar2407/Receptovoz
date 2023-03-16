using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Receptovoz.Data.Repository;
using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Data
{
    public class DatabaseManager
    {
        private static AppDBContent content;

        public static void SetDBContent(AppDBContent content)
        {
            DatabaseManager.content = content;
        }

        public static void AddRecipe(Recipe recipe)
        {
            content.Recipe.Add(recipe);
            content.SaveChanges();
        }

        public static int NextRecipeId() => content.Recipe.Max(recipe => recipe.id) + 1;
    }
}
