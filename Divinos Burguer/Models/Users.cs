using Plugin.Firebase.Firestore;

public class Users : IFirestoreObject
{
    // ID do documento (gerado automaticamente pelo Firestore)
    [FirestoreDocumentId]
    public string Id { get; set; } = string.Empty;

    // Nome do usuário (obrigatório)
    [FirestoreProperty("name")]
    public string Name { get; set; } = string.Empty;

    // Status do usuário (padrão: ativo)
    [FirestoreProperty("is_active")]
    public bool IsActive { get; private set; } = true;

    // Data de criação (imutável, definida apenas uma vez)
    [FirestoreProperty("created_at")]
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;

    // Data de atualização (gerada pelo servidor)
    [FirestoreServerTimestamp("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    // Data de exclusão lógica (nullable para indicar não excluído)
    [FirestoreProperty("deleted_at")]
    public DateTimeOffset? DeletedAt { get; private set; }

    // --- Métodos de Domínio (lógica relacionada ao usuário) ---

    /// <summary>
    /// Marca o usuário como excluído logicamente.
    /// </summary>
    public void SoftDelete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
        IsActive = false;
    }

    /// <summary>
    /// Restaura um usuário excluído logicamente.
    /// </summary>
    public void Restore()
    {
        DeletedAt = null;
        IsActive = true;
    }
}