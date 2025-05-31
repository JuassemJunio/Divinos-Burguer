using Plugin.Firebase.Firestore;

public interface IRepository<TEntity> where TEntity : class, IFirestoreObject
{
    Task<IDocumentReference> GetRefDocumentById(string id);
    Task<TEntity> GetByIdDocument(string id);

    Task<List<TEntity>> GetAllActiveDocuments();

    Task<string> CreateDocument(TEntity entity);

    Task AddDocument(TEntity entity, string id);

    Task DeleteDocument(string id);

    //Task<IEnumerable<TEntity>> GetAllAsync();
    //Task UpdateAsync(TEntity entity);
}