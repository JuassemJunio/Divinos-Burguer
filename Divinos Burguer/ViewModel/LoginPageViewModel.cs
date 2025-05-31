using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Auth.Google;
using Plugin.Firebase.Core.Exceptions;
using System.Diagnostics;

namespace Divinos_Burguer.ViewModel;

public partial class LoginPageViewModel : ObservableObject
{
    private readonly IFirebaseAuth _auth;
    private readonly IFirebaseAuthGoogle _authGoogle;
    private readonly IUserService _useService;
    private readonly ITermService _termService;

    public LoginPageViewModel(
        IFirebaseAuth auth,
        IFirebaseAuthGoogle authGoogle,
        IUserService userService,
        ITermService termService
        )
    {
        _auth = auth;
        _authGoogle = authGoogle;
        _useService = userService;
        _termService = termService;
    }

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    // Comando para realizar o login com email e senha
    [RelayCommand]
    private async Task Login()
    {
        // Verifica se o email e a senha foram preenchidos
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please enter both email and password", "OK");
            return;
        }

        try
        {
            var user = await _auth.SignInWithEmailAndPasswordAsync(Email, Password);
            if (!user.IsEmailVerified)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email não verificado, valide sua caixa de email.", "OK");
                return;
            }

            await HandleSuccessfulLogin(user);
        }
        catch (FirebaseException ex)
        {
            // Exibe uma mensagem de erro se o login falhar
            Console.WriteLine(ex);
            Debug.WriteLine(ex);
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // Comando para realizar o login com Google
    [RelayCommand]
    private async Task LoginWithGoogle()
    {

        if (_auth.CurrentUser != null)
            {
                await _authGoogle.SignOutAsync();
                await _auth.SignOutAsync();
            }

            IFirebaseUser firebaseUser = await _authGoogle.SignInWithGoogleAsync();

            Users user = await HandleSuccessfulLogin(firebaseUser);
   
    }

    // Método para lidar com o login bem-sucedido
    private async Task<Users> HandleSuccessfulLogin(IFirebaseUser firebaseUser)
    {
            Users user = await _useService.GetByIdDocument(firebaseUser.Uid);

            if(user != null)
            {

            }

            user = await CreateUserRecord(firebaseUser);
            await _auth.SignInWithCustomTokenAsync(firebaseUser.GetIdTokenResultAsync().ToString());

            return user;
     
        // Navega para a página principal após o login bem-sucedido
        //await Shell.Current.GoToAsync("//MainPage");
    }

    private async Task<Users> CreateUserRecord(IFirebaseUser firebaseUser)
    {
        var a = await _termService.GetAllActiveDocuments();

        var newUser = new Users
        {
            Id = firebaseUser.Uid,
            Name = firebaseUser.DisplayName ?? "Novo Usuário",
            Email = firebaseUser.Email,
            TermsID = _termService.GetRefDocumentById(a.FirstOrDefault()?.Id ?? string.Empty).Result,
        };

         await _useService.AddDocument(newUser, newUser.Id);

        return newUser;

    }
}
