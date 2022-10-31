using Casha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Instruction { get; set; }

        public string UserId { get; set; }  

        public User User { get; set; }

        public List<RecipeProduct> RecipeProducts { get; set; }

        public List<RecipeCategory> RecipeCategories { get; set; }
    }
}
