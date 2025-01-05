using Recipes.ViewModels;

namespace Recipes.Pages;

public partial class QRHandlerPage : ContentPage
{
	public QRHandlerPage(QRHandlerViewModel _vm)
	{		
		InitializeComponent();
		this.BindingContext = _vm;
	}
}