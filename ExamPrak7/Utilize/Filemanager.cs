using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ExamPrak7.Utilize
{
    public static class Filemanager
    {
        public static bool CheckSize(this IFormFile file, int kb)
        {
            if (file.Length / 1024 > kb) return true;

            return false;
            
        }
        public static bool CheckType(this IFormFile file, string path)
        {
            if (file.ContentType.Contains(path)) return true;

            return false;
        }
        public static string SaveImg(this IFormFile File, string savePath)
        {
            string fileName = Guid.NewGuid().ToString() + File.FileName;
            string fullPath = Path.Combine(savePath, fileName);
            using (FileStream fs = new FileStream(fullPath , FileMode.Create))
            {
                File.CopyTo(fs);
            }
            return fileName;
        }
        public static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
