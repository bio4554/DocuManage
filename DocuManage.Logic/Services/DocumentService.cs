using DocuManage.Data;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;

namespace DocuManage.Logic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documents;

        public DocumentService(IDocumentRepository documents)
        {
            _documents = documents;
        }

        public async Task<DocumentDto?> GetDocument(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            return await _documents.GetDocument(id);
        }
    }
}