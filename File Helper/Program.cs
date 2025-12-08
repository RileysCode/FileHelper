// See https://aka.ms/new-console-template for more information
using Microsoft.Win32.SafeHandles;

namespace File_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserExperience UX = new UserExperience();
            UserExperience.Welcome();
            UserExperience.Startup();
            UserExperience.ContinueOrStop();
        }
    }
}   
