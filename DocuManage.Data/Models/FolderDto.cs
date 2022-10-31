using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Data.Models
{
    public class FolderDto
    {
        public Guid Id { get; set; }
        public FolderDto Parent { get; set; }
    }
}
