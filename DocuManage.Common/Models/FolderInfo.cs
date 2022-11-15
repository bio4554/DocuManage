using DocuManage.Data.Models;

namespace DocuManage.Common.Models
{
    public class FolderInfo
    {
        public FolderDto Folder { get; set; }
        public FolderDto ParentFolder { get; set; }
        public DocumentInfo[]? Documents { get; set; }
        public FolderDto[]? Folders { get; set; }
        public string FullPath { get; set; }
    }
}