using Casha.Core.DbModels;
using Casha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.Dtos
{
    public class RecipeFilterDto
    {
        public string Name { get; set; } = "";

        public Difficulty? Difficulty { get; set; } = null;

        public string UserId { get; set; } = "";

        public List<int> RecipeProducts { get; set; } = new List<int>();

        public List<int> RecipeCategories { get; set; } = new List<int>();
    }
}
