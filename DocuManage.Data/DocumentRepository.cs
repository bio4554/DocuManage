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
            var response = _db.Set<DocumentDto>().Add(document);
            await _db.SaveChangesAsync();
            document.Id = response.Entity.Id;
            return document;
        }

        public async Task<FolderDto?> CreateFolder(FolderDto folder)
        {
            var response = _db.Set<FolderDto>().Add(folder);
            await _db.SaveChangesAsync();
            folder.Id = response.Entity.Id;
            return folder;
        }

        public List<FolderDto> GetChildrenFolders(Guid id)
        {
            var response = _db.Set<FolderDto>().Where(f => f.Parent == id).ToList();

            return response;
        }

        public List<DocumentDto> GetChildrenDocuments(FolderDto folder)
        {
            var response = _db.Set<DocumentDto>().Where(d => d.Folder == folder).ToList();

            return response;
        }

        public FolderDto? GetFolder(Guid id)
        {
            return _db.Set<FolderDto>().Find(id);
        }
    }
}