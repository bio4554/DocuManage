using DocuManage.Data.Models;

namespace DocuManage.Common.Models
{
    public class FolderDto
    {
        public Folder Folder { get; set; }
        public Folder ParentFolder { get; set; }
        public DocumentDto[]? Documents { get; set; }
        public Folder[]? Folders { get; set; }
        public string FullPath { get; set; }
    }
}