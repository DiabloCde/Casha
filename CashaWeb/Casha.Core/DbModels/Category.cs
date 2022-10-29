﻿using Casha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }
    
        public List<RecipeCategory> RecipeCategories { get; set; }  
    }
}
