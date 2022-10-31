using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Data.Models
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FolderDto Folder { get; set; }
    }
}
