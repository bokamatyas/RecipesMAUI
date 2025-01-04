using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Pages;

public partial class ViewRecipePage : ContentPage
{
    //public RecipeDataModel? InputRecipeData { get; set; }
    public ViewRecipePage(ViewRecipeViewModel _vm)
	{
        InitializeComponent();
		this.BindingContext = _vm;
        //_vm.RecipeData = InputRecipeData;
    }
}