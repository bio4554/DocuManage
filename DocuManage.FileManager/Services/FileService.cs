using DocuManage.Common.Interfaces;
using DocuManage.FileManager.Exceptions;
using DocuManage.FileManager.Interfaces;
using Microsoft.Extensions.Logging;

namespace DocuManage.FileManager.Services
{
    public class FileService : IFileService
    {
        private readonly string _basepath;
        private readonly ILogger _log;

        public FileService(IConfig config, ILoggerFactory loggerFactory)
        {
            _basepath = config.FileBasePath;
            _log = loggerFactory.CreateLogger<FileService>();
        }

        public async Task<byte[]?> GetFile(string fileName)
        {
            var path = Path.Combine(_basepath, fileName);

            if (File.Exists(path))
            {
                var bytes = await File.ReadAllBytesAsync(path);
                return bytes;
            }

            _log.LogWarning("FileService failed to find file: {0}", path);

            return null;
        }

        public async Task<string> UploadFile(byte[] file, string fileName, bool overwrite)
        {
            var path = Path.Combine(_basepath, fileName);

            if (!overwrite && File.Exists(path))
            {
                throw new FileOverwriteException($"Tried to overwrite file: {path}");
            }

            await File.WriteAllBytesAsync(path, file);

            return path;
        }
    }
}
