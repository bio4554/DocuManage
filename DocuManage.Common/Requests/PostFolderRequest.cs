using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Requests
{
    public class PostFolderRequest
    {
        [Required]
        public string Name { get; set; }
        public Guid? Parent { get; set; }
    }
}
