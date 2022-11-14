using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Common.Interfaces;

namespace DocuManage.Common.Services
{
    public class Config : IConfig
    {
        public string BlobStorageConnectionString { get; set; }
        public string BlobStorageContainerName { get; set; }
    }
}
