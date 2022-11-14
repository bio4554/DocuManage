using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Interfaces
{
    public interface IConfig
    {
        public string BlobStorageConnectionString { get; set; }
        public string BlobStorageContainerName { get; set; }
    }
}
