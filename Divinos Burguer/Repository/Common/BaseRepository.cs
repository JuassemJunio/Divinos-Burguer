using Plugin.Firebase.Firestore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        var document = await _firestore
            .GetCollection(CollectionName)
            .GetDocument(id)
            .GetDocumentSnapshotAsync<TEntity>();

        return (TEntity)document;
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

    //public async Task AddAsync(TEntity entity)
    //{
    //    await _firestore
    //        .GetCollection(CollectionName)
    //        .AddDocumentAsync(entity);
    //}

    //public async Task UpdateAsync(TEntity entity)
    //{
    //    await _firestore
    //        .GetCollection(CollectionName)
    //        .GetDocument(entity.Id)
    //        .SetDataAsync(entity);
    //}

    //public async Task DeleteAsync(string id)
    //{
    //    await _firestore
    //        .GetCollection(CollectionName)
    //        .GetDocument(id)
    //        .DeleteDocumentAsync();
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