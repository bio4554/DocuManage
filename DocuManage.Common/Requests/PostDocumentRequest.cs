using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Common.Requests
{
    public class PostDocumentRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid Folder { get; set; }
        [Required]
        public List<IFormFile> File { get; set; }
    }
}
