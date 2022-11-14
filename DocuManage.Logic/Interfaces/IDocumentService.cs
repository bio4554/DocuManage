using DocuManage.Common.Models;
using DocuManage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Logic.Interfaces
{
    public interface IDocumentService
    {
        public Task<DocumentDto?> GetDocument(Guid id);

        public Task<DocumentDto?> CreateDocument(DocumentDto document);

        public Task<FolderInfo?> CreateFolder(FolderDto folder);

        public Task<FolderInfo?> GetFolder(Guid id);
    }
}
