using Divinos_Burguer.ViewModel;

namespace Divinos_Burguer.Views;

public partial class LoginPage : ContentPage
{
    private LoginPageViewModel _viewModel;
    public LoginPage()
	{
		InitializeComponent();
        BindingContext = _viewModel = new LoginPageViewModel();
    }
}