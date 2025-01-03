﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using Recipes.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        public List<RecipeDataModel>? recipesData;

        [ObservableProperty]
        public RecipeDataModel? selectedRecipeData;

        [RelayCommand]
        private void Appearing()
        {
            try
            {
                RecipesData = Task.Run(() => RecipeDataBase.GetAllItemsAsync()).Result;
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
        private void NewRecipe()
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    DataControlPage.InputRecipeData = new RecipeDataModel();
                    await Shell.Current.GoToAsync($"//{nameof(DataControlPage)}", true);
                });
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }
    }
}
