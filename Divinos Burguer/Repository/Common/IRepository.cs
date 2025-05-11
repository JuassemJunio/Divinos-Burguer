using Plugin.Firebase.Firestore;

public interface IRepository<TEntity> where TEntity : class, IFirestoreObject
{
    Task<TEntity> GetByIdAsync(string id);
    //Task<IEnumerable<TEntity>> GetAllAsync();
    //Task AddAsync(TEntity entity);
    //Task UpdateAsync(TEntity entity);
    //Task DeleteAsync(string id);
}