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
    public partial class ViewRecipeViewModel: ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public RecipeDataModel? recipeData;

        [ObservableProperty]
        public string? ingredients;

        public void ApplyQueryAttributes(IDictionary<string, object> _queryAttributes)
        {
            int id = int.Parse(_queryAttributes["recipeId"].ToString());
            RecipeData = Task.Run(() => RecipeDataBase.GetItemAsync(id)).Result;
        }

        [RelayCommand]
        private void Edit()
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "recipeData", RecipeData },
                    };
                    await Shell.Current.GoToAsync($"{nameof(DataControlPage)}", true, navigationParameters);
                    navigationParameters.Clear();
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

        [RelayCommand]
        private async Task Delete()
        {
            try
            {
                if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to delete the recipe?", "Yes", "No"))
                {
                    await RecipeDataBase.DeleteItemAsync(RecipeData);
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

        [RelayCommand]
        private async Task Share()
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "recipeData", RecipeData },
                    };
                    await Shell.Current.GoToAsync($"{nameof(QRHandlerPage)}", true, navigationParameters);
                    navigationParameters.Clear();
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

        [RelayCommand]
        private async Task OpenLink()
        {
            try
            {
                Uri uri = new Uri(RecipeData.InstructionsURL);
                BrowserLaunchOptions options = new()
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Colors.DarkBlue,
                    PreferredControlColor = Colors.White,
                };
                await Browser.Default.OpenAsync(uri, options);

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
