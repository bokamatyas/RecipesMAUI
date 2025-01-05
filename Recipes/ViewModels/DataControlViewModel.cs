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
using Application = Microsoft.Maui.Controls.Application;

namespace Recipes.ViewModels
{
    public partial class DataControlViewModel: ObservableObject, IQueryAttributable
    {

        [ObservableProperty]
        public RecipeDataModel? recipeData;


        public void ApplyQueryAttributes(IDictionary<string, object> _queryAttributes)
        {
            RecipeData = _queryAttributes["recipeData"] as RecipeDataModel;
        }


        [RelayCommand]
        private async Task Save()
        {
            
            try
            {
                if (await InputCheck())
                {
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
                    return false;
                };
                if (String.IsNullOrWhiteSpace(RecipeData.InstructionsURL))
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "Please provide a URL link to your recipe", "OK");
                    return false;
                };
                return true;
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
