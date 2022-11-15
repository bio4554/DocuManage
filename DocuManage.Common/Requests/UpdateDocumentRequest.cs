using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Requests
{
    public class UpdateDocumentRequest
    {
        public string? Name { get; set; }
        public Dictionary<string, string>? Metadata { get; set; }
        public string? Folder { get; set; }
    }
}
