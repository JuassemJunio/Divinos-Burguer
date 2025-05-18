using Plugin.Firebase.Firestore;

public interface IRepository<TEntity> where TEntity : class, IFirestoreObject
{
    Task<TEntity> GetByIdAsync(string id);
    Task AddAsync(TEntity entity, string id);
    Task DeleteAsync(string id);
    //Task<IEnumerable<TEntity>> GetAllAsync();
    //Task UpdateAsync(TEntity entity);
}