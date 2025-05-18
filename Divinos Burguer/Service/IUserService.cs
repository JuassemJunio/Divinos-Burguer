public interface IUserService
{
    Task<Users> GetUserByIdAsync(string id);
    Task AddUserAsync(Users user, string id);
    Task SoftDeleteUserAsync(string userId);
    //Task<Users> GetUserByEmailAsync(string email);
    //Task<IEnumerable<Users>> GetActiveUsersAsync();
    //Task UpdateUserAsync(Users user);
    //Task<string> UploadUserPhotoAsync(string userId, byte[] imageData);
    //Task<bool> AuthenticateAsync(string email, string password);
}