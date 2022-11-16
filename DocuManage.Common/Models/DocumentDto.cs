using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Models
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public long FileSize { get; set; }
    }
}
