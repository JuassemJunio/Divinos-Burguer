using Plugin.Firebase.Firestore;

public interface ITermService
{
    Task<IDocumentReference> GetRefDocumentById(string id);
    Task<Terms> GetByIdDocument(string id);
    Task AddDocument(Terms term, string id);
    Task<string> CreateDocument(Terms term);
    Task DeleteDocument(string Id);
    Task<List<Terms>> GetAllActiveDocuments();
}
