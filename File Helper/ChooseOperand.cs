public class ChooseOperand
{
    public string getOperator()
    {
        UserExperience UX = new UserExperience();
        while (true)
        {
            UserExperience.SpacedHighlight("Choose an operation to get started.");
            Console.WriteLine("Type '1' to remove a prefix. Type '2' to add Prefix");
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2))
                {
                Console.WriteLine("Invalid choice. Please enter '1' or '2'.");
                continue;
                }
            else
                {
                return choice.ToString();
                }
        }
    }
}