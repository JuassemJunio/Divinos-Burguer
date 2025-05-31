
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Operações básicas
    public async Task<Users> GetByIdDocument(string id)
        => await _userRepository.GetByIdDocument(id);

    public async Task AddDocument(Users user, string id)
     => await _userRepository.AddDocument(user, id);

    public async Task DeleteDocument(string userId)
        => await _userRepository.DeleteDocument(userId);

    public async Task GetAllActiveDocuments()
        => await _userRepository.GetAllActiveDocuments();

    //public async Task<Users> GetUserByEmailAsync(string email)
    //    => await _userRepository.GetByEmailAsync(email);

    //public async Task<IEnumerable<Users>> GetActiveUsersAsync()
    //    => await _userRepository.GetActiveUsersAsync();



    //public async Task UpdateUserAsync(Users user)
    //    => await _userRepository.UpdateAsync(user);



    // Autenticação
    //public async Task<bool> AuthenticateAsync(string email, string password)
    //{
    //    try
    //    {
    //        var result = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
    //        return result.User != null;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

    //// Storage
    //public async Task<string> UploadUserPhotoAsync(string userId, byte[] imageData)
    //{
    //    var reference = _firebaseStorage
    //        .Reference
    //        .Child("user_photos")
    //        .Child($"{userId}.jpg");

    //    await reference.PutBytesAsync(imageData);
    //    return await reference.GetDownloadUrlAsync();
    //}
}