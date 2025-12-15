using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.IO;

public class PathHandler
{
    public static char[] invalidChars = Path.GetInvalidPathChars();
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
}
