using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public partial class ViewRecipeViewModel: ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public RecipeDataModel? recipeData;

        public void ApplyQueryAttributes(IDictionary<string, object> _queryAttributes)
        {
            RecipeData = _queryAttributes["recipeData"] as RecipeDataModel;
        }

    }
}
