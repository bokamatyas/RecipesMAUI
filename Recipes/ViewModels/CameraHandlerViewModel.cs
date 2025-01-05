using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
using Recipes.Models;
using Recipes.Pages;

namespace Recipes.ViewModels
{
    public partial class CameraHandlerViewModel: ObservableObject
    {
        public Grid? CameraGrid { get; set; }

        private CameraBarcodeReaderView? Camera { get; set; }

        [RelayCommand]
        private void Appearing()
        {
            CreateCameraView();
        }


        private void CreateCameraView()
        {

            try
            {
                if (CameraGrid != null)
                {
                    CameraGrid.Children.Clear();
                    Camera = new CameraBarcodeReaderView();
                    Camera.BarcodesDetected += BarCodesDetected!;
                    CameraGrid.Children.Add(Camera);
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

        private async void BarCodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            try
            {
                Camera!.IsDetecting = false;
                string[] qrData = e.Results[0].Value.Split(';');
                RecipeDataModel recipeData = new
                    (
                        qrData[0],
                        int.Parse(qrData[1]),
                        qrData[2],
                        qrData[3]
                    );
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var navigationParameters = new Dictionary<string, object>
                    {
                        { "recipeData", recipeData },
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
                await Application.Current.MainPage.DisplayAlert("Warning", "Data could not be converted!", "OK");
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
                return;
            }

        }
    }
}
