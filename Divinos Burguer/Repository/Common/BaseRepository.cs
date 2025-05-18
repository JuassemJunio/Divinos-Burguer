using Plugin.Firebase.Firestore;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IFirestoreObject
{
    protected readonly IFirebaseFirestore _firestore;
    protected abstract string CollectionName { get; }

    public BaseRepository(IFirebaseFirestore firestore)
    {
        _firestore = firestore;
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        IDocumentSnapshot<TEntity> document = await _firestore
            .GetCollection(CollectionName)
            .GetDocument(id)
            .GetDocumentSnapshotAsync<TEntity>();

        return document.Data;
    }

    public async Task AddAsync(TEntity entity, string id)
    {
       await _firestore
           .GetCollection(CollectionName)
           .GetDocument(id) 
           .SetDataAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _firestore
            .GetCollection(CollectionName)
            .GetDocument(id)
            .DeleteDocumentAsync();
    }

    //public async Task<IEnumerable<TEntity>> GetAllAsync()
    //{
    //    var querySnapshot = await _firestore
    //        .GetCollection(CollectionName)
    //        .GetQuerySnapshotAsync<TEntity>();

    //    return querySnapshot?.Documents
    //        .Select(doc => doc.ToObject<TEntity>())
    //        .ToList() ?? new List<TEntity>();
    //}



    //public async Task UpdateAsync(TEntity entity)
    //{
    //    await _firestore
    //        .GetCollection(CollectionName)
    //        .GetDocument(entity.Id)
    //        .SetDataAsync(entity);
    //}



    //// Método auxiliar para queries customizadas
    //protected async Task<IEnumerable<TEntity>> GetWhereAsync(string field, object value)
    //{
    //    var querySnapshot = await _firestore
    //        .GetCollection(CollectionName)
    //        .WhereEqualsTo(field, value)
    //        .GetQuerySnapshotAsync<TEntity>();

    //    return querySnapshot?.Documents
    //        .Select(doc => doc.ToObject<TEntity>())
    //        .ToList() ?? new List<TEntity>();
    //}
}