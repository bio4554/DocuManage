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
    }
}
