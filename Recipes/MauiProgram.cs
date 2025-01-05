using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Recipes.Pages;
using Recipes.ViewModels;
using ZXing.Net.Maui.Controls;

namespace Recipes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<DataControlPage>();
            builder.Services.AddSingleton<DataControlViewModel>();
            builder.Services.AddSingleton<ViewRecipePage>();
            builder.Services.AddSingleton<ViewRecipeViewModel>();
            builder.Services.AddSingleton<QRHandlerPage>();
            builder.Services.AddSingleton<QRHandlerViewModel>();
            builder.Services.AddSingleton<CameraHandlerPage>();
            builder.Services.AddSingleton<CameraHandlerViewModel>();
            Routing.RegisterRoute(nameof(ViewRecipePage), typeof(ViewRecipePage));
            Routing.RegisterRoute(nameof(DataControlPage), typeof(DataControlPage));
            Routing.RegisterRoute(nameof(QRHandlerPage), typeof(QRHandlerPage));
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
