using System;
using System.IO;
using IMDB.Domain.Interfaces;

namespace RiadIMDB.iOS.IoC
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _personalFolder;

        public FileStorageService()
        {
            _personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
        public bool FileExists(string folder, string filename)
        {
            var filePath = GetPath(folder, filename);
            return File.Exists(filePath);
        }

        public string SaveFile(byte[] file, string folder, string filename)
        {
            var filePath = GetPath(folder, filename);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllBytes(filePath, file);
            return filePath;
        }

        public string GetPath(string folder, string filename)
        {
            var prefix = filename.StartsWith("/", StringComparison.InvariantCultureIgnoreCase) ? "" : "/";
            var filePath = $"{_personalFolder}/{folder}/{filename}";
            return Path.GetDirectoryName(filePath + $"{prefix}{filename}");
        }

        public byte[] GetFile(string folder, string filename)
        {
            var filePath = GetPath(folder, filename);
            return File.ReadAllBytes(filePath);
        }
    }
}
