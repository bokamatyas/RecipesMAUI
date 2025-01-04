using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Pages;

public partial class DataControlPage : ContentPage
{    
	public DataControlPage(DataControlViewModel _vm)
	{
		InitializeComponent();
		this.BindingContext = _vm;
	}
}