
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Operações básicas
    public async Task<Users> GetUserByIdAsync(string id)
        => await _userRepository.GetByIdAsync(id);

    //public async Task<Users> GetUserByEmailAsync(string email)
    //    => await _userRepository.GetByEmailAsync(email);

    //public async Task<IEnumerable<Users>> GetActiveUsersAsync()
    //    => await _userRepository.GetActiveUsersAsync();

    //public async Task AddUserAsync(Users user)
    //    => await _userRepository.AddAsync(user);

    //public async Task UpdateUserAsync(Users user)
    //    => await _userRepository.UpdateAsync(user);

    //public async Task SoftDeleteUserAsync(string userId)
    //    => await _userRepository.SoftDeleteAsync(userId);

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