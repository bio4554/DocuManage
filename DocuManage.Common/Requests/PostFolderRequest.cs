using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Requests
{
    public class PostFolderRequest
    {
        public string Name { get; set; }
        public Guid? Parent { get; set; }
    }
}
