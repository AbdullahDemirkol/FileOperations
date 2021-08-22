using System;
using System.Collections.Generic;
using System.IO;

namespace ConvertingFilesToImages
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\1\Desktop\asdasd";
            string[] files = FetchFiles(path);
            List<string> results = PreparationToAddPngToImage(files);
            PrintResults(results);
        }

        public static void PrintResults(List<string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static void PrintToConsolse(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                Console.WriteLine(fileName);
            }
        }

        public static string[] FetchFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }

        public static List<string> PreparationToAddPngToImage(string[] files)
        {
            List<string> results = new();
            string extension, fileName, result;
            foreach (var file in files)
            {
                try
                {
                    extension = Path.GetExtension(file);
                    AddPngToName(file, extension);
                    fileName = Path.GetFileName(file);
                    result = $"Başarılı. Dosyanın Adı : {fileName}";
                    results.Add(result);
                }
                catch (Exception ex)
                {
                    result = $@"Başarısız. Hata Mesajı:{ex.Message} ---- Hata Satırı:{ex.StackTrace}";
                    results.Add(result);
                }
            }
            return results;
        }

        public static void AddPngToName(string fileName, string extension)
        {
            if (extension != ".png" && extension != ".gif" && extension != ".jpg")
            {
                File.Move(fileName, fileName + ".png");
            }
        }

    }
}
