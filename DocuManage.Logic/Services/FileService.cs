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

        public async Task<string> UploadFile(IFormFile file)
        {
            var fileStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(fileStream);

            var response = _blobService.UploadBlob(fileStream, "test", "test");

            return await response;
        }
    }
}
