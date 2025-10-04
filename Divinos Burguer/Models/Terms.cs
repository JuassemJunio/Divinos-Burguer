using Plugin.Firebase.Firestore;

public class Terms : IFirestoreObject
{
    [FirestoreDocumentId]
    public string Id { get; set; } = string.Empty;

    [FirestoreProperty("version")]
    public string Version { get; set; } = string.Empty;

    [FirestoreProperty("content")]
    public string Content { get; set; } = string.Empty;

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