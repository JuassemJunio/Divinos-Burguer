using Plugin.Firebase.Firestore;
using System.Text.RegularExpressions;

public sealed class Address : IFirestoreObject
{
    // Identificador único (gerado pelo Firestore)
    [FirestoreDocumentId]
    public string Id { get; private set; } = string.Empty;

    // Dados do endereço
    [FirestoreProperty("street")]
    public string Street { get; set; } = string.Empty;

    [FirestoreProperty("number")]
    public string Number { get; set; } = string.Empty;

    [FirestoreProperty("city")]
    public string City { get; set; } = string.Empty;

    [FirestoreProperty("state")]
    public string State { get; set; } = string.Empty;

    [FirestoreProperty("zip_code")]
    public string ZipCode
    {
        get => _zipCode;
        set => _zipCode = ValidateZipCode(value);
    }
    private string _zipCode = string.Empty;

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

    // Validação de CEP
    private static string ValidateZipCode(string zipCode)
    {
        if (!Regex.IsMatch(zipCode, @"^\d{5}-?\d{3}$"))
            throw new ArgumentException("CEP inválido. Formato esperado: 12345-678 ou 12345678");
        return zipCode.Replace("-", "");
    }
}