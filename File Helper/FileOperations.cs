using System;
using System.IO;
using System.Linq;

public class FileOperations
{
    public static void removePrefix(string path, string prefix)
    {
        var files = Directory.GetFiles(path).Where(filePath => Path.GetFileName(filePath).StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
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
        var files = Directory.GetFiles(path).Where(path => !Path.GetFileName(path).StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
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

    public static void addSuffix(string path, string suffix)
    {
        bool HasSuffix(string filePath, string sfx)
        {
            var fileName = Path.GetFileName(filePath);
            var nameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            return fileName.EndsWith(sfx, StringComparison.OrdinalIgnoreCase) || nameWithoutExt.EndsWith(sfx, StringComparison.OrdinalIgnoreCase);
        }

        var files = Directory.GetFiles(path).Where(filePath => !HasSuffix(filePath, suffix));
        if (!files.Any())
        {
            Console.WriteLine("All files have the specified suffix.");
            return;
        }
        else
        {
            Console.WriteLine("Adding suffix " + suffix + " to " + files.Count() + " files...");
            foreach (var file in files)
            {
                string oldFileName = file;
                string newFileName = Path.GetFileNameWithoutExtension(file) + suffix + Path.GetExtension(file);
                string location = Path.Combine(path, newFileName);
                File.Move(oldFileName, location);
                Console.WriteLine("Renamed: " + oldFileName + " to " + newFileName);
            }
        }
    }
    public static void removeSuffix(string path, string suffix)
    {
        suffix = suffix?.Trim() ?? string.Empty;
        bool HasSuffix(string filePath, string sfx)
        {
            var fileName = Path.GetFileName(filePath);
            var nameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            return fileName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) || nameWithoutExt.EndsWith(suffix, StringComparison.OrdinalIgnoreCase);
        }

        var files = Directory.GetFiles(path).Where(filePath => HasSuffix(filePath, suffix));
        if (!files.Any())
        {
            Console.WriteLine("No files found with the specified suffix.");
            return;
        }
        else
        {
            Console.WriteLine(files.Count() + " files were found. Removing Suffix " + suffix + "...");
            foreach (var file in files)
            {
                string oldFullPath = file;
                string originalFileName = Path.GetFileName(oldFullPath);
                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalFileName);
                string ext = Path.GetExtension(originalFileName);
                string newFileName;
                if (nameWithoutExt.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) && nameWithoutExt.Length >= suffix.Length)
                {
                    string newNameWithoutExt = nameWithoutExt.Substring(0, nameWithoutExt.Length - suffix.Length);
                    newFileName = newNameWithoutExt + ext;
                }
                else if (originalFileName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) && originalFileName.Length >= suffix.Length)
                {
                    newFileName = originalFileName.Substring(0, originalFileName.Length - suffix.Length);
                }
                else
                {
                    continue;
                }
                string location = Path.Combine(path, newFileName);
                File.Move(oldFullPath, location);
                Console.WriteLine("Renamed: " + originalFileName + " to " + newFileName);
            }
        }
    }
}