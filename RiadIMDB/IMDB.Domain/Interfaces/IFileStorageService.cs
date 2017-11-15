namespace IMDB.Domain.Interfaces
{
    public interface IFileStorageService
    {
        string SaveFile(byte[] file, string folder, string filename);
        bool FileExists(string folder, string filename);
        byte[] GetFile(string folder, string filename);
        string GetPath(string folder, string filename);
    }
}
