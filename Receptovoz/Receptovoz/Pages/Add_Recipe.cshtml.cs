using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receptovoz.Data;
using Receptovoz.Models;

namespace Receptovoz.Pages
{
    public class AddRecipeModel : PageModel
    {
        private IHostingEnvironment environment;

        public AddRecipeModel(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        [BindProperty]
        [Required]
        public string RecipeName { get; set; }

        [BindProperty]
        public string SearchTags { get; set; }

        [BindProperty]
        public string KiloCalories { get; set; }

        [BindProperty]
        public string CookingTime { get; set; }

        [BindProperty]
        public string Ingredients { get; set; }

        [BindProperty]
        [Required]
        public string Instructions { get; set; }

        [BindProperty]
        public string Notes { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostUpload(List<IFormFile> photos)
        {
            if (ModelState.IsValid)
            {
                List<string> parsedSearchTags = new List<string>();
                if (SearchTags != null)
                    foreach (string searchTag in SearchTags.Trim().Split(";"))
                        parsedSearchTags.Add(searchTag.Trim().ToLower());

                int parsedKiloCalories = 0;
                if (KiloCalories != null)
                    _ = int.TryParse(KiloCalories.Trim(), out parsedKiloCalories);

                string parsedCookingTime = "";
                if (CookingTime != null)
                    parsedCookingTime = CookingTime.Trim().ToLower();

                List<string> parsedIngredients = new List<string>();
                if (Ingredients != null)
                    foreach (string line in Ingredients.Split("\n"))
                        if (line.Trim() != string.Empty)
                            parsedIngredients.Add(line.Trim().ToLower());

                List<string> parsedInstructions = new List<string>();
                if (Instructions != null)
                {
                    foreach (string line in Instructions.Trim().Split("\n"))
                    {
                        if (line.Trim() != string.Empty)
                        {
                            string capitalizedLine = line.Trim().ToLower();
                            capitalizedLine = capitalizedLine.Substring(0, 1).ToUpper() + capitalizedLine[1..];
                            parsedInstructions.Add(capitalizedLine);
                        }
                    }
                }

                List<string> parsedNotes = new List<string>();
                if (Notes != null)
                {
                    foreach (string line in Notes.Split("\n"))
                    {
                        if (line.Trim() != string.Empty)
                        {
                            string capitalizedLine = line.Trim().ToLower();
                            capitalizedLine = capitalizedLine.Substring(0, 1).ToUpper() + capitalizedLine[1..];
                            parsedNotes.Add(capitalizedLine);
                        }
                    }
                }

                int recipeId = DatabaseManager.NextRecipeId();

                List<string> resultPhotoUrls = new List<string>();
                if (photos != null)
                {
                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "images", $"recipe{recipeId}");

                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);

                    for (int photoIndex = 0; photoIndex < photos.Count; ++photoIndex)
                    {
                        string photoFileName = $"result{photoIndex + 1}.png";
                        string photoFilePath = Path.Combine(directoryPath, photoFileName);

                        resultPhotoUrls.Add($"recipe{recipeId}/{photoFileName}");

                        using (FileStream photoFileStream = new FileStream(photoFilePath, FileMode.Create))
                            photos[photoIndex].CopyTo(photoFileStream);
                    }
                }

                Recipe newRecipe = new Recipe
                {
                    name = RecipeName.Trim(),
                    uploadDate = DateTime.Now,
                    searchTags = parsedSearchTags.ToArray(),
                    kiloCalories = parsedKiloCalories,
                    cookingTime = parsedCookingTime,

                    ingredients = parsedIngredients.ToArray(),
                    instructions = parsedInstructions.ToArray(),
                    notes = parsedNotes.ToArray(),

                    photoUrls = resultPhotoUrls.ToArray()
                };

                DatabaseManager.AddRecipe(newRecipe);

                return Redirect("/");
            }

            return Page();
        }
    }
}
