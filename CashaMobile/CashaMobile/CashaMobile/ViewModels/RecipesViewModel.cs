using System;
using System.Collections.Generic;
using System.Text;
using CashaMobile.Models.Enums;
using System.Linq;
using CashaMobile.Helpers;
using CashaMobile.Services.Interfaces;

namespace CashaMobile.ViewModels
{
    public class RecipesViewModel : ViewModelBase
    {
        private RecipeFilter _filter;
        private IRecipeService _recipeService;
        



        public RecipeFilter Filter
        {
            get { return _filter; }
            set 
            { 
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }

        public List<string> FiltreValues
        {
            get
            {
                return Enum.GetNames(typeof(RecipeFilter))
                    .Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public RecipesViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }



    }
}
