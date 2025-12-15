public class ChooseOperand
{
    public string getOperator()
    {
        UserExperience UX = new UserExperience();
        while (true)
        {
            UserExperience.SpacedHighlight("Choose an operation to get started.");
            Console.WriteLine("Type '1' to remove a prefix. Type '2' to add Prefix");
            Console.WriteLine("Type 3 to Add a suffix, Type 4 to remove a suffix.");
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2 && choice != 3 && choice != 4))
            {
                Console.WriteLine("Invalid choice. Please enter '1' , '2' , '3' , or '4'.");
                continue;
            }
            else
            {
                return choice.ToString();
            }
        }
    }
}