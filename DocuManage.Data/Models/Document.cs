using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Data.Interfaces;

namespace DocuManage.Data.Models
{
    public class Document : IUniqueIdentifier
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid Folder { get; set; }
        public string? FileId { get; set; }
        public string? Metadata { get; set; }
        public long FileSize { get; set; }
    }
}
