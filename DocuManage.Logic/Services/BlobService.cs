using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using DocuManage.Common.Interfaces;
using DocuManage.Logic.Interfaces;

namespace DocuManage.Logic.Services
{
    public class BlobService : IBlobService
    {
        private readonly IConfig _config;
        public BlobService(IConfig config)
        {
            _config = config;
        }

        public async Task<string> UploadBlob(MemoryStream blob, string name, string path)
        {
            var client = new BlobContainerClient(_config.BlobStorageConnectionString, _config.BlobStorageContainerName);

            var blobClient = client.GetBlobClient(name);

            var response = await blobClient.UploadAsync(blob);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<MemoryStream> GetBlob(Guid id)
        {
            var client = new BlobContainerClient(_config.BlobStorageConnectionString, _config.BlobStorageContainerName);

            var blobClient = client.GetBlobClient(id.ToString());

            var response = await blobClient.DownloadAsync();

            var fileStream = new MemoryStream();

            await response.Value.Content.CopyToAsync(fileStream);

            fileStream.Position = 0;

            return fileStream;
        }
    }
}
