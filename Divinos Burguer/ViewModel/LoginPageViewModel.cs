using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Auth.Google;
using Plugin.Firebase.Firestore;

namespace Divinos_Burguer.ViewModel;

public partial class LoginPageViewModel : ObservableObject
{
    private readonly IFirebaseAuth _auth;
    private readonly IFirebaseAuthGoogle _authGoogle;
    private readonly IFirebaseFirestore _firestore;
    private readonly IUserRepository _userRepository;

    // Construtor da ViewModel, inicializa as dependências com valores padrão se não forem fornecidos
    public LoginPageViewModel(
        IFirebaseAuth auth = null,
        IFirebaseAuthGoogle authGoogle = null,
        IFirebaseFirestore firestore = null,
        IUserRepository userRepository = null
        )
    {
        _auth = auth ?? CrossFirebaseAuth.Current;
        _authGoogle = authGoogle ?? CrossFirebaseAuthGoogle.Current;
        _userRepository = userRepository;
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
            // Tenta realizar o login com email e senha
            var user = await _auth.SignInWithEmailAndPasswordAsync(Email, Password);
            await HandleSuccessfulLogin(user);
        }
        catch (Exception ex)
        {
            // Exibe uma mensagem de erro se o login falhar
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // Comando para realizar o login com Google
    [RelayCommand]
    private async Task LoginWithGoogle()
    {
        try
        {
            // Desconecta qualquer sessão anterior do Google
            await _authGoogle.SignOutAsync();
            // Tenta realizar o login com Google
            var result = await _authGoogle.SignInWithGoogleAsync();
            await HandleSuccessfulLogin(result);
        }
        catch (Exception ex)
        {
            // Exibe uma mensagem de erro se o login falhar
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // Método para lidar com o login bem-sucedido
    private async Task HandleSuccessfulLogin(IFirebaseUser user)
    {

        var a = await _userRepository.GetByIdAsync(user.Uid);

        //var userDocRef = _firestore.GetDocument($"users/{user.Uid}");


        //var userDocSnapshot = await userDocRef.GetDocumentSnapshotAsync<Users>();


        //if (userDocSnapshot.Data != null)
        //{

        //    await CreateUserRecord(user);
        //}

        // Navega para a página principal após o login bem-sucedido
        //await Shell.Current.GoToAsync("//MainPage");
    }

    // Método para criar um registro de usuário no Firestore
    private async Task CreateUserRecord(IFirebaseUser firebaseUser)
    {
        // Verifica se o firebaseUser é nulo e lança uma exceção apropriada
        if (firebaseUser == null)
        {
            throw new ArgumentNullException(nameof(firebaseUser), "O usuário Firebase não pode ser nulo.");
        }

        // Cria uma nova instância de Users com os dados do firebaseUser
        //var newUser = new Users
        //{
        //    Id = firebaseUser.Uid,
        //    Name = firebaseUser.DisplayName ?? "Novo Usuário", // Usa "Novo Usuário" se DisplayName for nulo
        //    IsActive = true,
        //    CreatedAt = DateTimeOffset.UtcNow // Define a data de criação como o momento atual em UTC
        //};

        // Obtém a referência do documento no Firestore
        var documentReference = _firestore.GetDocument($"users/{firebaseUser.Uid}");
        if (documentReference == null)
        {
            throw new InvalidOperationException("A referência do documento é nula.");
        }

        // Define os dados do novo usuário no documento Firestore
        //await documentReference.SetDataAsync(newUser);
    }
}
