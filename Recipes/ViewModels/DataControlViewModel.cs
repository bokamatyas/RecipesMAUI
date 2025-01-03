using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public partial class DataControlViewModel: ObservableObject
    {

        [ObservableProperty]
        public RecipeDataModel? recipeData;
    }
}
