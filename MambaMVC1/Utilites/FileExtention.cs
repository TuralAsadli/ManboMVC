namespace MambaMVC1.Utilites
{
    public static class FileExtention
    {
        public static bool CheckSize(this IFormFile file)
        {
            if (file.Length / 1024 > 2)
            {
                return false;
            }

            return true;
        }

        public static bool CheckFileType(this IFormFile file)
        {
            if (!file.ContentType.Contains("image"))
            {
                return false;
            }
            return true;
            
        }

        public static string ChangeFileName(this IFormFile file)
        {
            return Guid.NewGuid().ToString() + file.FileName;
        }

        public static void CreateFile(this IFormFile file, string path)
        {
            if (file == null)
            {
                return;
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
        }

        public static void Delete(string path)
        {
            if (path == null)
            {
                return;
            }

            File.Delete(path);
        }
    }
}
