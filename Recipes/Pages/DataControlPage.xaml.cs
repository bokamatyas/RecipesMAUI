using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Pages;

public partial class DataControlPage : ContentPage
{    
	public static RecipeDataModel? InputRecipeData { get; set; }
	public DataControlPage(DataControlViewModel _vm)
	{
		InitializeComponent();
		this.BindingContext = _vm;
		_vm.RecipeData = InputRecipeData;
	}
}