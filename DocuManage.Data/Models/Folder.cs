using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Data.Interfaces;

namespace DocuManage.Data.Models
{
    public class Folder : IUniqueIdentifier
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid? Parent { get; set; }
    }
}
