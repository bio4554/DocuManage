using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Logic.Interfaces
{
    public interface IBlobService
    {
        public Task<string> UploadBlob(MemoryStream blob, string name, string path);
        public Task<MemoryStream> GetBlob(Guid id);
    }
}
