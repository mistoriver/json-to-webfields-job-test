using System;
using System.IO;
using System.Threading.Tasks;

namespace DynamicFieldsApp.Helpers
{
    public static class FileHelper
    {
        public static string GetTextFromFile(string path)
        {
            var result = "";
            try
            {
                using (FileStream fstream = File.OpenRead(path))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    result = System.Text.Encoding.Default.GetString(array);
                }
            }
            catch (Exception e)
            { 
                throw new Exception("Произошла ошибка при получении файла. Возможно, он лежит не там или называется не так", e); 
            }
            return result;
        }
        public async static Task<string> GetTextFromFileAsync(string path)
        {
            return await Task.Run(() => GetTextFromFile(path));
        }
    }
}
