using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Amlak.Core.SSOT
{
    public static class FileHelper
    {
        public static string SaveFile(IFormFile file, FileConfig config, string fileType)
        {
            if (file.Length <= 0) { throw new Exception("there is no content in uploaded file."); }

            var date = DateTime.Now;
            var relativePath = $"{fileType}/{date.Year}/{date.Month}/{date.Day}/";
            var folderPath = Path.Combine(config.PhysicalAddress, relativePath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            Directory.CreateDirectory(folderPath);
            var filepath = Path.Combine(folderPath, fileName);

            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Path.Combine(relativePath, fileName);
        }
    }
}