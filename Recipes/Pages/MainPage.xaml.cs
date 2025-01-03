using Recipes.ViewModels;

namespace Recipes.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel _vm)
        {
            InitializeComponent();
            this.BindingContext = _vm;
        }
        
    }

}
