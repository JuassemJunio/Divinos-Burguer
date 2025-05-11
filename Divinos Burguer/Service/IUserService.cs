public interface IUserService
{
    Task<Users> GetUserByIdAsync(string id);
    //Task<Users> GetUserByEmailAsync(string email);
    //Task<IEnumerable<Users>> GetActiveUsersAsync();
    //Task AddUserAsync(Users user);
    //Task UpdateUserAsync(Users user);
    //Task SoftDeleteUserAsync(string userId);
    //Task<string> UploadUserPhotoAsync(string userId, byte[] imageData);
    //Task<bool> AuthenticateAsync(string email, string password);
}