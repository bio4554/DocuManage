using DocuManage.Data.DB;
using DocuManage.Data.Models;

namespace DocuManage.Data
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BackendContext _db;

        public DocumentRepository(BackendContext db)
        {
            _db = db;
        }

        public async Task<DocumentDto?> GetDocument(Guid id)
        {
            var retrieved = await _db.Set<DocumentDto>().FindAsync(id);

            return retrieved;
        }

        public async Task<DocumentDto?> CreateDocument(DocumentDto document)
        {
            _db.Set<DocumentDto>().Add(document);
            await _db.SaveChangesAsync();
            return document;
        }
    }
}