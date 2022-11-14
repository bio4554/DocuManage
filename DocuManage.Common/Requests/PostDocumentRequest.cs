using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Common.Requests
{
    public class PostDocumentRequest
    {
        public string Name { get; set; }
        public Guid Folder { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
