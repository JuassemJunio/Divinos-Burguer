using Plugin.Firebase.Firestore;

public class TermService : ITermService
{
    private readonly ITermRepository _termRepository;

    public TermService(
        ITermRepository termRepository)
    {
        _termRepository = termRepository;
    }

    // Operações básicas
    public async Task<IDocumentReference> GetRefDocumentById(string id)
        => await _termRepository.GetRefDocumentById(id);
    public async Task<Terms> GetByIdDocument(string id)
        => await _termRepository.GetByIdDocument(id);

    public async Task AddDocument(Terms term, string id)
     => await _termRepository.AddDocument(term, id);

    public async Task<string> CreateDocument(Terms term)
     => await _termRepository.CreateDocument(term);

    public async Task DeleteDocument(string userId)
        => await _termRepository.DeleteDocument(userId);

    public async Task<List<Terms>> GetAllActiveDocuments()
        => await _termRepository.GetAllActiveDocuments();
}