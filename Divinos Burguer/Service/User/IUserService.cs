using Plugin.Firebase.Firestore;

public interface IUserService
{
    Task<IDocumentReference> GetRefDocumentById(string id);
    Task<Users> GetByIdDocument(string id);
    Task AddDocument(Users user, string id);
    Task UpdateDocument(Users user, string id);
    Task<string> CreateDocument(Users user);
    Task DeleteDocument(string userId);
    Task<List<Users>> GetAllActiveDocuments();
    //Task<Users> GetUserByEmailAsync(string email);
    //Task<IEnumerable<Users>> GetActiveUsersAsync();
    //Task UpdateUserAsync(Users user);
    //Task<string> UploadUserPhotoAsync(string userId, byte[] imageData);
    //Task<bool> AuthenticateAsync(string email, string password);
}