using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using Recipes.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using ZXing.QrCode.Internal;


namespace Recipes.ViewModels
{
    public partial class QRHandlerViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public string? recipeDataString;
        public void ApplyQueryAttributes(IDictionary<string, object> _queryAttributes)
        {
            RecipeDataModel inputRecipe = _queryAttributes["recipeData"] as RecipeDataModel;
            if (inputRecipe != null)
                RecipeDataString = $"{inputRecipe.Name};0;{inputRecipe.InstructionsURL};{inputRecipe.ImageUrl}";
        }

    }
}
