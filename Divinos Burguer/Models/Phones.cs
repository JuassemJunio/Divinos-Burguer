using Plugin.Firebase.Firestore;
using System.Text.RegularExpressions;

public sealed class Phones : IFirestoreObject
{
    [FirestoreDocumentId]
    public string Id { get; private set; } = string.Empty;

    [FirestoreProperty("number")]
    public string Number
    {
        get => _number;
        set => _number = ValidatePhoneNumber(value);
    }
    private string _number = string.Empty;

    [FirestoreProperty("type")] // Ex: "Celular", "Casa", "Trabalho"
    public string Type { get; set; } = string.Empty;

    [FirestoreProperty("is_primary")]
    public bool IsPrimary { get; set; }

    [FirestoreProperty("verified")]
    public bool Verified { get; set; } = false;

    [FirestoreProperty("is_active")]
    public bool IsActive { get; set; } = true;

    // Timestamp de criação (definido apenas uma vez)
    [FirestoreProperty("created_at")]
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    // Timestamp de atualização (atualizado automaticamente)
    [FirestoreServerTimestamp("updated_at")]
    public DateTimeOffset UpdatedAt { get; private set; }

    // Soft Delete (marcação lógica de exclusão)
    [FirestoreProperty("deleted_at")]
    public DateTimeOffset? DeletedAt { get; private set; } = null;

    // Método para "excluir" logicamente
    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
        IsActive = false;
    }

    // Método para restaurar usuário "excluído"
    public void Restore()
    {
        DeletedAt = null;
        IsActive = true;
    }

    // Validação básica de telefone (ajuste conforme necessidades)
    private static string ValidatePhoneNumber(string number)
    {
        var cleaned = Regex.Replace(number, @"[^\d]", "");
        if (cleaned.Length < 10 || cleaned.Length > 11)
            throw new ArgumentException("Número inválido. Use DDD + número (ex: 11987654321)");
        return cleaned;
    }
}