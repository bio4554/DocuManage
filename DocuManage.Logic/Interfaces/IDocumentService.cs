using DocuManage.Common.Models;
using DocuManage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Logic.Interfaces
{
    public interface IDocumentService
    {
        public Task<DocumentDto?> GetDocument(Guid id);
        public Task<DocumentInfo?> GetDocumentInfo(Guid id);

        public Task<DocumentDto?> CreateDocument(DocumentDto document, IFormFile formFile);

        public Task<FolderInfo?> CreateFolder(FolderDto folder);

        public Task<FolderInfo?> GetFolderInfo(Guid id);
        public Task<FolderDto?> GetFolder(Guid id);
        public Task<MemoryStream> GetFileStream(Guid id);
    }
}
