using DocuManage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Data
{
    public interface IDocumentRepository
    {
        public Task<DocumentDto?> GetDocument(Guid id);
        public Task<FolderDto?> CreateFolder(FolderDto folder);
        public Task<DocumentDto?> CreateDocument(DocumentDto document);
        public FolderDto? GetFolder(Guid id);
        public List<DocumentDto> GetChildrenDocuments(FolderDto folder);
        public List<FolderDto> GetChildrenFolders(Guid id);
    }
}
