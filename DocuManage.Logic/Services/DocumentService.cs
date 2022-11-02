using DocuManage.Common.Models;
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

        public async Task<DocumentDto?> CreateDocument(DocumentDto document)
        {
            if (string.IsNullOrEmpty(document.Name))
                return null;

            if (document.Folder == null)
                return null;

            var response = await _documents.CreateDocument(document);

            return response;
        }

        public async Task<FolderInfo?> CreateFolder(FolderDto folder)
        {
            if (string.IsNullOrEmpty(folder.Name))
            {
                return null;
            }

            var dto = await _documents.CreateFolder(folder);

            if (dto == null)
                return null;

            var response = new FolderInfo(folder.Name, dto, Array.Empty<DocumentDto>(), Array.Empty<FolderDto>());

            return response;
        }

        public async Task<FolderInfo?> GetFolder(Guid id)
        {
            var folder = _documents.GetFolder(id);
            if (folder == null)
                return null;

            var childFolders = _documents.GetChildrenFolders(id);
            var childDocs = _documents.GetChildrenDocuments(folder);

            var response = new FolderInfo(folder.Name, folder, childDocs.ToArray(), childFolders.ToArray());

            return response;
        }
    }
}