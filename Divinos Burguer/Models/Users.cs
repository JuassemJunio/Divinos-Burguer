using Plugin.Firebase.Firestore;

public class Users : IFirestoreObject
{
    [FirestoreDocumentId]
    public string Id { get; set; } = string.Empty;

    [FirestoreProperty("name")]
    public string Name { get; set; } = string.Empty;

    [FirestoreProperty("email")]
    public string Email { get; set; } = string.Empty;

    [FirestoreProperty("photoUrl")]
    public string PhotoUrl { get; set; } = string.Empty;

    [FirestoreProperty("terms_id")]
    public IDocumentReference TermsID { get; set; } = default!;

    [FirestoreProperty("is_active")]
    public bool IsActive { get; set; } = true;

    [FirestoreProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    [FirestoreServerTimestamp("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [FirestoreProperty("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; } 

    public void SoftDelete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
        IsActive = false;
    }

    public void Restore()
    {
        DeletedAt = null;
        IsActive = true;
    }
}
