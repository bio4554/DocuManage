using DocuManage.Data.Models;

namespace DocuManage.Common.Models
{
    public class FolderInfo
    {
        public string Name { get; set; }
        public FolderDto Folder { get; set; }
        public DocumentDto[] Documents { get; }

        public FolderDto[] Folders { get; }

        public FolderInfo(string name, FolderDto folder, DocumentDto[] documents, FolderDto[] folders)
        {
            this.Name = name;
            this.Folder = folder;
            this.Documents = documents;
            this.Folders = folders;
        }
    }
}