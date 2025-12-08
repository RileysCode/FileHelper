public class UserExperience
{
    public static void Welcome()
    {
        highlightText("Welcome to the File Helper!");
        Console.WriteLine("Do not use special characters in any new prefixes.");
        Console.WriteLine("This program does not have undo options.");
        Console.WriteLine("Avoid system directories, and backup any important files BEFORE proceeding.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public static void Farewell()
    {
        SpacedHighlight("Thank you for using the File Helper. Goodbye!");
        Thread.Sleep(2000);
        System.Environment.Exit(0);
    }
    public static  string getprefix(string choice)
    {
        var isRemove = false;
        if (choice == "1")
        {
            isRemove = true;
        }
        Console.WriteLine("Enter the prefix you would like to " + (isRemove ? "remove:" : "add:"));
        string prefix = Console.ReadLine() ?? string.Empty;
        if (prefix.Contains('*') || prefix == "" || prefix.Contains(':') || prefix.Contains('"') || prefix.Contains('/') || prefix.Contains('\\') || prefix.Contains('?') || prefix.Contains('\"') || prefix.Contains('<') || prefix.Contains('>') || prefix.Contains('|'))
        {
            Console.WriteLine("The prefix contains invalid characters. Please avoid using special characters.");
            return getprefix(choice);
        }
        return prefix;

    }
    public static void Startup()
    {
        PathHandler pathHandler = new PathHandler();
        ChooseOperand chooseOperand = new ChooseOperand();
        string choice = chooseOperand.getOperator();
        if (choice == "1")
        {
            SpacedHighlight("Prefix removal selected.");
            string directory = pathHandler.getDirectory();
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("The specified directory does not exist.");
                ContinueOrStop();
                return;
            }
            string prefixToRemove = getprefix(choice);
            int filesAffected = Directory.GetFiles(directory)
            .Where(filesAffected => Path.GetFileName(filesAffected)
            .StartsWith(prefixToRemove, StringComparison.OrdinalIgnoreCase)).Count();
            SpacedHighlight("There are no undo options. Currently, " + filesAffected + " files will be affected.");
            Console.WriteLine("Are you sure you want to remove the prefix");
            SpacedHighlight("'" + prefixToRemove + "'");
            Console.WriteLine("From " + filesAffected + " files in directory '" + directory + "'?");
            BlankLine();
            Console.WriteLine("Type 'yes' to confirm, otherwise cancels operation.");
            string Accept = Console.ReadLine() ?? string.Empty;
            if (Accept.ToLower() != "yes")
            {
                Console.WriteLine("Operation cancelled.");
                ContinueOrStop();
                return;
            }
            else
            {
                PathHandler.removePrefix(directory, prefixToRemove);
                ContinueOrStop();
            }
        }
        else if (choice == "2")
        {
            highlightText("Prefix addition selected.");
            BlankLine();
            string Dir = pathHandler.getDirectory();
            if (!Directory.Exists(Dir))
            {
                Console.WriteLine("The specified directory does not exist.");
                ContinueOrStop();
                return;
            }
            Console.WriteLine("Enter prefix to add:");
            string prefixToAdd = getprefix(choice);
            int affectedFiles = Directory.GetFiles(Dir)
            .Where(affectedFiles => !Path.GetFileName(affectedFiles)
            .StartsWith(prefixToAdd, StringComparison.OrdinalIgnoreCase)).Count();
            
            SpacedHighlight("There are no undo options. Currently, " + affectedFiles + " files will be affected.");
            Console.WriteLine("Are you sure you want to add the prefix");
            SpacedHighlight("'" + prefixToAdd + "'");
            Console.WriteLine("To " + affectedFiles + " files in directory '" + Dir + "'?");
            Console.WriteLine("Example result: " + prefixToAdd + "File.txt");
            BlankLine();
            Console.WriteLine("Type 'yes' to confirm, otherwise cancels operation.");
            string confirmation = Console.ReadLine() ?? string.Empty;
            if (confirmation.ToLower() != "yes")
            {
                Console.WriteLine("Operation cancelled.");
                ContinueOrStop();
                return;
            }
            else
            {
                PathHandler.addPrefix(Dir, prefixToAdd);
                ContinueOrStop();
            }
        }
        else
        {
            Console.WriteLine("An unexpected error has occurred.");
            ContinueOrStop();
        }
    }
    public static void ContinueOrStop()
    {
        SpacedHighlight("Would you like to restart the program?");
        Console.WriteLine("Type 'yes' to restart, or anything else to exit.");
        if (Console.ReadLine() == "yes")
        {
            Startup();
        }
        else
        {
            Farewell();
            Environment.Exit(0);
        }
    }
    public static void highlightText(string text)
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public static void BlankLine()
    {
        Console.WriteLine("");
    }
    public static void SpacedHighlight(string text)
    {
        BlankLine();
        highlightText(text);
        BlankLine();
    }
}
