using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using DocuManage.Logic.Interfaces;

namespace DocuManage.Logic.Services
{
    public class BlobService : IBlobService
    {
        public async Task<string> UploadBlob(MemoryStream blob, string name, string path)
        {
            var client = new BlobContainerClient(
                new Uri("https://127.0.0.1:10000/devstoreaccount1/file-testing"), new DefaultAzureCredential()
            );
            var blobClient = client.GetBlobClient(name);

            var response = await blobClient.UploadAsync(blob);

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
