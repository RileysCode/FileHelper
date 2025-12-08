using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.IO;

public class PathHandler
{
     public string getDirectory()
    {
        while (true)
        {
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine()?? string.Empty;
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Invalid file path.");
                continue;
            }
            return filePath;
        }
    }
    public static void removePrefix(string path, string prefix)
    {
        var files = Directory.GetFiles(path)
        .Where(filePath => Path.GetFileName(filePath)
        .StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        
        if (!files.Any())
        {
            Console.WriteLine("No files found with the specified prefix.");
            return;
        }
        else
        {
            Console.WriteLine(files.Count() + " files were found. Removing Prefix " + prefix + "...");
            foreach (var file in files)
            {
                string oldFullPath = file;
                string originalfileName = Path.GetFileName(oldFullPath);
                string newFileName = Path.GetFileName(originalfileName.Substring(prefix.Length));
                string newFullPath = Path.Combine(path, newFileName);
                string location = Path.Combine(path, newFileName);
                File.Move(oldFullPath, location);
                Console.WriteLine("Renamed: " + originalfileName + " to " + newFileName);
            }
        }
    }
    public static void addPrefix(string path, string prefix)
    {
        var files = Directory.GetFiles(path)
        .Where(path => !Path.GetFileName(path)
        .StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        if (!files.Any())
        {
            Console.WriteLine("All files already have the specified prefix.");
            return;
        }
        else
        {
            Console.WriteLine("Adding Prefix '" + prefix + "' to " + files.Count() + " files");
            foreach (var file in files)
            {
                string oldFileName = file;
                string newFileName = prefix + Path.GetFileName(file);
                string location =  Path.Combine(path, newFileName);
                File.Move(oldFileName, location);
                Console.WriteLine("Renamed: " + oldFileName + " to " + newFileName);
            }
        }
    }
}
