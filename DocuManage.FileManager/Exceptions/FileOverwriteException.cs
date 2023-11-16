namespace DocuManage.FileManager.Exceptions
{
    public class FileOverwriteException : Exception
    {
        public FileOverwriteException() : base() { }

        public FileOverwriteException(string message) : base(message) { }
    }
}
