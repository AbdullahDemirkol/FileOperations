using System;
using System.Collections.Generic;
using System.IO;

namespace SeparatingFiles
{
    class Program
    {

        static void Main(string[] args)
        {
            string sourceFolderPath = @"C:\Users\1\Desktop\Yeni klasör\Karışık";
            string destinationFolderPath = @"C:\Users\1\Desktop\Abdullah\Müzikler\Düzeltilicek Müzikler\Yeni klasör";
            string[] files = FetchFiles(sourceFolderPath);
            List<string> foldersToMove = ChooseFileType(files);
            if (foldersToMove != null)
            {
                List<string> results = MovePictures(foldersToMove, destinationFolderPath);
                PrintResults(results);
            }
        }

        public static List<string> ChooseFileType(string[] files)
        {
            Console.WriteLine("Taşımak istediğiniz dosya türü:");
            Console.WriteLine("1-Müzikler");
            Console.WriteLine("2-Resimler");
            Console.WriteLine("3-Videolar");
            Console.WriteLine("4-Text Dosyaları");
            int selectedFileType = Convert.ToInt32(Console.ReadLine());
            List<string> foldersToMove = new();
            switch (selectedFileType)
            {
                case 1:
                    foldersToMove = CheckMusicFiles(files);
                    break;
                case 2:
                    foldersToMove = CheckPhotoFiles(files);
                    break;
                case 3:
                    foldersToMove = CheckVideoFiles(files);
                    break;
                case 4:
                    foldersToMove = CheckTextFiles(files);
                    break;
                default:
                    Console.WriteLine("Hatalı Tuşlama Yapıldı");
                    return null;
            }
            return foldersToMove;
        }

        public static void PrintResults(List<string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static List<string> MovePictures(List<string> filesToBeMove, string destinationFolderPath)
        {
            List<string> results = new();
            string result, fileName;
            foreach (var fileToBeMove in filesToBeMove)
            {
                fileName = Path.GetFileName(fileToBeMove);
                try
                {
                    File.Move(fileToBeMove, GenerateFileName(destinationFolderPath, fileName));
                    result = $"Başarılı";
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

        public static string GenerateFileName(string destinationFolderPath, string fileName)
        {
            string destinationFile = destinationFolderPath + @"\" + fileName;
            return destinationFile;
        }

        public static string[] FetchFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }

        public static List<string> CheckPhotoFiles(string[] files)
        {
            List<string> filesToBeMoved = new();
            string extension;
            foreach (var file in files)
            {
                extension = Path.GetExtension(file);
                if (extension == ".png" || extension == ".gif" || extension == ".jpg")
                {
                    filesToBeMoved.Add(file);
                }
            }
            return filesToBeMoved;
        }

        public static List<string> CheckVideoFiles(string[] files)
        {
            List<string> filesToBeMoved = new();
            string extension;
            foreach (var file in files)
            {
                extension = Path.GetExtension(file);
                if (extension == ".mp4")
                {
                    filesToBeMoved.Add(file);
                }
            }
            return filesToBeMoved;
        }

        public static List<string> CheckMusicFiles(string[] files)
        {
            List<string> filesToBeMoved = new();
            string extension;
            foreach (var file in files)
            {
                extension = Path.GetExtension(file);
                if (extension == ".mp3")
                {
                    filesToBeMoved.Add(file);
                }
            }
            return filesToBeMoved;
        }

        public static List<string> CheckTextFiles(string[] files)
        {
            List<string> filesToBeMoved = new();
            string extension;
            foreach (var file in files)
            {
                extension = Path.GetExtension(file);
                if (extension == ".txt")
                {
                    filesToBeMoved.Add(file);
                }
            }
            return filesToBeMoved;
        }

    }
}
