using Plugin.Firebase.Firestore;

public class Users : IFirestoreObject
{
    [FirestoreDocumentId]
    public string Id { get; set; } = string.Empty;

    [FirestoreProperty("name")]
    public string Name { get; set; } = string.Empty;

    [FirestoreProperty("is_active")]
    public bool IsActive { get; set; } = true; // Alterado para set público

    [FirestoreProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; // Alterado para set público

    [FirestoreServerTimestamp("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [FirestoreProperty("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; } // Alterado para set público

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
