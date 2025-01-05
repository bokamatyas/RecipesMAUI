using Recipes.ViewModels;

namespace Recipes.Pages;

public partial class CameraHandlerPage : ContentPage
{
	public CameraHandlerPage(CameraHandlerViewModel _vm)
	{
		InitializeComponent();
		this.BindingContext = _vm;
		_vm.CameraGrid = this.cameraGrid;
	}
}