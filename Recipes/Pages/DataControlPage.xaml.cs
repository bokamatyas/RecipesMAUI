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

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        (sender as Slider).Value = Math.Round((sender as Slider).Value);
		LBL_rating.Text = $"{(sender as Slider).Value}/10";

    }
}