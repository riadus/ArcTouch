using System;
using System.IO;
using IMDB.Common;
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
            if (filePath == null)
            {
                return false;
            }
            return File.Exists(filePath);
        }

        public void SaveFile(byte[] file, string folder, string filename)
        {
            var filePath = GetPath(folder, filename);
            if (filePath == null)
            {
                return;
            }
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllBytes(filePath, file);
        }

        public string GetPath(string folder, string filename)
        {
            if (string.IsNullOrEmpty(filename)) return null;
            var prefix = filename.StartsWith("/", StringComparison.InvariantCultureIgnoreCase) ? "" : "/";
            var filePath = $"{_personalFolder}/{folder}/{filename}";
            return Path.GetDirectoryName(filePath + $"{prefix}{filename}");
        }
    }
}
