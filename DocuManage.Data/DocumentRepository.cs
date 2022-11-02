using DocuManage.Data.DB;

namespace DocuManage.Data
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BackendContext _db;

        public DocumentRepository(BackendContext db)
        {
            _db = db;
        }
    }
}