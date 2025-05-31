public interface IUserService
{
    Task<Users> GetByIdDocument(string id);
    Task AddDocument(Users user, string id);
    Task DeleteDocument(string userId);
    Task GetAllActiveDocuments();
    //Task<Users> GetUserByEmailAsync(string email);
    //Task<IEnumerable<Users>> GetActiveUsersAsync();
    //Task UpdateUserAsync(Users user);
    //Task<string> UploadUserPhotoAsync(string userId, byte[] imageData);
    //Task<bool> AuthenticateAsync(string email, string password);
}