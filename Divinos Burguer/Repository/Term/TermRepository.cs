using Plugin.Firebase.Firestore;

public class TermRepository : BaseRepository<Terms>, ITermRepository
{
    public TermRepository(IFirebaseFirestore firestore) : base(firestore) { }

    protected override string CollectionName => "terms";

}
