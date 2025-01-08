using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using Recipes.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<RecipeDataModel>? recipesData;

        [ObservableProperty]
        public RecipeDataModel? selectedRecipeData;

        [ObservableProperty]
        public List<int>? recipeIds;

        [RelayCommand]
        private void Appearing()
        {
            try
            {
                RecipesData = Task.Run(() => RecipeDataBase.GetAllItemsAsync()).Result.OrderByDescending(r => r.Rating).ToList();
                RecipeIds = RecipesData.Select(r => r.Id).ToList();
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
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "recipeData", new RecipeDataModel() },
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

        async partial void OnSelectedRecipeDataChanged(RecipeDataModel? value)
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "recipeId", SelectedRecipeData.Id },
                    };
                    await Shell.Current.GoToAsync($"{nameof(ViewRecipePage)}", true, navigationParameters);
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

        public void ToggleShake()
        {
            try
            {
                if (Accelerometer.IsSupported)
                {
                    if (!Accelerometer.Default.IsMonitoring)
                    {
                        Accelerometer.Default.ShakeDetected += Default_ShakeDetected;
                        Accelerometer.Default.Start(SensorSpeed.Game);
                    }
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

        private async void Default_ShakeDetected(object? sender, EventArgs e)
        {
            try
            {
                if (RecipesData is not null && RecipeIds is not null)
                {
                    Random rnd = new Random();
                    int id = RecipeIds[rnd.Next(0, RecipeIds.Count)];
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        var navigationParameters = new Dictionary<string, object>
                        {
                        { "recipeId", id },
                        };
                        while (Shell.Current.Navigation.NavigationStack.Count > 1)
                        {
                            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[1]);
                        }
                        await Shell.Current.GoToAsync($"{nameof(ViewRecipePage)}", true, navigationParameters);
                        navigationParameters.Clear();
                    });
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Warning", "You have no recipes!", "OK");
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
