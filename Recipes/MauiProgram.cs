using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Recipes.Pages;
using Recipes.ViewModels;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<DataControlPage>();
            builder.Services.AddSingleton<DataControlViewModel>();
            builder.Services.AddSingleton<ViewRecipePage>();
            builder.Services.AddSingleton<ViewRecipeViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
