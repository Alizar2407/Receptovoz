using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Models
{
    public class Recipe
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime uploadDate { get; set; }

        public string[] searchTags { get; set; }

        public int kiloCalories { get; set; }

        public string cookingTime { get; set; }

        public string[] photoUrls { get; set; }

        public string[] ingredients { get; set; }

        public string[] instructions { get; set; }

        public string[] notes { get; set; }
    }
}
