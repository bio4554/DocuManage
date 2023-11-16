namespace DocuManage.FileManager.Interfaces
{
    public interface IFileService
    {
        Task<byte[]?> GetFile(string fileName);
        Task<string> UploadFile(byte[] file, string fileName, bool overwrite);
    }
}
