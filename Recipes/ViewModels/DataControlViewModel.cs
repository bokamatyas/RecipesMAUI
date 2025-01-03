using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using Recipes.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Microsoft.Maui.Controls.Application;

namespace Recipes.ViewModels
{
    public partial class DataControlViewModel: ObservableObject
    {

        [ObservableProperty]
        public RecipeDataModel? recipeData;

        [ObservableProperty]
        public string? ingredients;

        [ObservableProperty]
        public string? instructions;

        [RelayCommand]
        private void Appearing()
        {
            try
            {
                Ingredients = String.Join('\n', RecipeData.Ingredients);
                Instructions = String.Join('\n', RecipeData.Instructions);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }

        [RelayCommand]
        private async Task Back()
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }

            [RelayCommand]
        private async Task Save()
        {
            
            try
            {
                if (!await InputCheck())
                {
                    RecipeData.Ingredients = String.Join(';', Ingredients.Split('\n'));
                    RecipeData.Instructions = String.Join(';', Instructions.Split('\n'));
                    if (String.IsNullOrWhiteSpace(RecipeData.ImageUrl)) RecipeData.ImageUrl = "noimage.png";
                    await RecipeDataBase.SaveItemAsync(RecipeData);
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }

        private async Task<bool> InputCheck()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(RecipeData.Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "Name must be given!", "OK");
                    return true;
                };
                if (String.IsNullOrWhiteSpace(Ingredients))
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "At least 1 ingredient is required!", "OK");
                    return true;
                };
                return false;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return false;
            }            
        }
    }
}
