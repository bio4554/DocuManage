using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DocuManage.Common.Models;
using DocuManage.Common.Requests;
using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using DocuManage.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        public async Task<DocumentInfo?> CreateDocument(DocumentDto document, IFormFile formFile)
        {
            if (string.IsNullOrEmpty(document.Name))
                return null;

            if (document.Folder == null)
                return null;

            var fileId = await _fileService.UploadFileAsync(formFile);

            document.FileId = fileId;
            document.FileSize = formFile.Length;
            document.Metadata ??= JsonSerializer.Serialize(new Dictionary<string, string>());

            _documents.Insert(document);

            _documents.SaveChanges();

            return await GetDocumentInfo(document.Id ?? Guid.Empty);
        }

        public async Task<FolderInfo?> CreateFolder(FolderDto folder)
        {
            if (string.IsNullOrEmpty(folder.Name))
            {
                return null;
            }

            _documents.Insert(folder);
            _documents.SaveChanges();

            var response = new FolderInfo()
            {
                Documents = Array.Empty<DocumentInfo>(),
                Folder = folder,
                Folders = Array.Empty<FolderDto>(),
                ParentFolder = _documents.Single<FolderDto>(folder.Parent ?? Guid.Empty),
                FullPath = GetFullPath(folder)
            };

            return response;
        }

        public async Task<FolderInfo?> GetFolderInfo(Guid id)
        {
            var folder = _documents.Single<FolderDto>(id);
            if (folder == null)
                return null;

            var childFolders = _documents.GetAll<FolderDto>().Where(f => f.Parent == id).ToArray();
            var childDocs = _documents.GetAll<DocumentDto>().Where(d => d.Folder == id).ToArray();

            var documents = new List<DocumentInfo>();

            foreach (var doc in childDocs)
            {
                documents.Add(await GetDocumentInfo(doc.Id ?? Guid.Empty));
            }

            var response = new FolderInfo()
            {
                Documents = documents.ToArray(),
                Folder = folder,
                Folders = childFolders.ToArray(),
                ParentFolder = _documents.Single<FolderDto>(folder.Parent ?? Guid.Empty),
                FullPath = GetFullPath(folder)
            };

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
                Path = pathBuilder.ToString(),
                FileSize = document.FileSize,
                Metadata = JsonSerializer.Deserialize<Dictionary<string, string>>(document.Metadata)
            };

            return response;
        }

        private string GetFullPath(FolderDto folder)
        {
            var pathBuilder = new StringBuilder();
            var currentFolder = folder;

            if (currentFolder == null)
                throw new Exception("Folder mismatch");

            while (currentFolder != null)
            {
                pathBuilder.Append("/");
                pathBuilder.Append(currentFolder.Name);
                currentFolder = _documents.Single<FolderDto>(currentFolder.Parent ?? Guid.Empty);
            }

            return pathBuilder.ToString();
        }

        public async Task<DocumentInfo?> UpdateDocument(Guid id, UpdateDocumentRequest request)
        {
            var document = _documents.Single<DocumentDto>(id);
            if (document == null) return null;

            if (!string.IsNullOrEmpty(request.Name))
            {
                document.Name = request.Name;
            }

            if (request.Folder != null)
            {
                document.Folder = new Guid(request.Folder);
            }

            if (request.Metadata != null && request.Metadata.Any())
            {
                Dictionary<string, string> metadata = null;
                if (!string.IsNullOrEmpty(document.Metadata))
                {
                    metadata = JsonSerializer.Deserialize<Dictionary<string, string>>(document.Metadata);
                }
                
                metadata ??= new Dictionary<string, string>();

                foreach (var pair in request.Metadata)
                {
                    metadata[pair.Key] = pair.Value;
                }

                document.Metadata = JsonSerializer.Serialize(metadata);
            }

            _documents.SaveChanges();

            return await GetDocumentInfo(id);
        }
    }
}