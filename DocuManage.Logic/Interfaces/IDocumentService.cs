using DocuManage.Common.Models;
using DocuManage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Common.Requests;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Logic.Interfaces
{
    public interface IDocumentService
    {
        public Task<Document?> GetDocument(Guid id);
        public Task<DocumentDto?> GetDocumentInfo(Guid id);

        public Task<DocumentDto?> CreateDocument(Document document, IFormFile formFile);

        public Task<FolderDto?> CreateFolder(Folder folder);

        public Task<FolderDto?> GetFolderInfo(Guid id);
        public Task<Folder?> GetFolder(Guid id);
        public Task<MemoryStream> GetFileStream(Guid id);
        public Task<DocumentDto?> UpdateDocument(Guid id, UpdateDocumentRequest request);
    }
}
