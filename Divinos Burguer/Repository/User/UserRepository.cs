using Plugin.Firebase.Firestore;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    public UserRepository(IFirebaseFirestore firestore) : base(firestore) { }

    protected override string CollectionName => "users";


}