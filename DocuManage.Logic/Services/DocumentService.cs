using System.Text;
using DocuManage.Common.Models;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Logic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documents;
        private readonly IFileService _fileService;

        public DocumentService(IDocumentRepository documents, IFileService fileService)
        {
            _documents = documents;
            _fileService = fileService;
        }

        public async Task<DocumentDto?> GetDocument(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            return _documents.Single<DocumentDto>(id);
        }

        public async Task<DocumentDto?> CreateDocument(DocumentDto document, IFormFile formFile)
        {
            if (string.IsNullOrEmpty(document.Name))
                return null;

            if (document.Folder == null)
                return null;

            var fileId = await _fileService.UploadFileAsync(formFile);

            document.FileId = fileId;

            _documents.Insert(document);

            _documents.SaveChanges();

            return document;
        }

        public async Task<FolderInfo?> CreateFolder(FolderDto folder)
        {
            if (string.IsNullOrEmpty(folder.Name))
            {
                return null;
            }

            _documents.Insert(folder);
            _documents.SaveChanges();

            var response = new FolderInfo(folder.Name, folder, Array.Empty<DocumentDto>(), Array.Empty<FolderDto>());

            return response;
        }

        public async Task<FolderInfo?> GetFolderInfo(Guid id)
        {
            var folder = _documents.Single<FolderDto>(id);
            if (folder == null)
                return null;

            var childFolders = _documents.GetAll<FolderDto>().Where(f => f.Parent == id);
            var childDocs = _documents.GetAll<DocumentDto>().Where(d => d.Folder == id);

            var response = new FolderInfo(folder.Name, folder, childDocs.ToArray(), childFolders.ToArray());

            return response;
        }

        public async Task<FolderDto?> GetFolder(Guid id)
        {
            return _documents.Single<FolderDto>(id);
        }

        public async Task<MemoryStream?> GetFileStream(Guid id)
        {
            var document = _documents.Single<DocumentDto>(id);

            if (document == null) return null;

            return await _fileService.GetFileAsync(new Guid(document.FileId ?? string.Empty));
        }

        public async Task<DocumentInfo?> GetDocumentInfo(Guid id)
        {
            var document = _documents.Single<DocumentDto>(id);

            if (document is null) return null;


            var pathBuilder = new StringBuilder();

            var currentFolder = _documents.Single<FolderDto>(document.Folder);

            if (currentFolder == null) 
                throw new Exception("Folder mismatch");

            while (currentFolder != null)
            {
                pathBuilder.Append("/");
                pathBuilder.Append(currentFolder.Name);
                currentFolder = _documents.Single<FolderDto>(currentFolder.Parent ?? Guid.Empty);
            }

            var response = new DocumentInfo()
            {
                Id = document.Id ?? Guid.Empty,
                Title = document.Name,
                Path = pathBuilder.ToString()
            };

            return response;
        }
    }
}