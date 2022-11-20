using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<RecipeProduct> RecipeProducts { get; set; }
        
        public List<UserProduct> UserProducts { get; set; }
    }
}
