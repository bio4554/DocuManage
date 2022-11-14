using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Logic.Services
{
    public class FileService : IFileService
    {
        private readonly IBlobService _blobService;

        public FileService(IBlobService blobService)
        {
            _blobService = blobService;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(fileStream);

            fileStream.Position = 0;

            var safeName = Guid.NewGuid();

            var response = await _blobService.UploadBlob(fileStream, safeName.ToString(), "test");

            return safeName.ToString();
        }

        public async Task<MemoryStream> GetFileAsync(Guid id)
        {
            return await _blobService.GetBlob(id);
        }
    }
}
