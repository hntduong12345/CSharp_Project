namespace TestAPI.Services.FileService
{
    public interface IFileService
    {
        void Upload(Stream fileStream, string filename);
    }
}
