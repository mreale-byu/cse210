class Menu
{

    public enum Choice : ushort
    {
        BreathingActivity = 1,
        ReflectingActivity = 2,
        ListingActivity = 3,
        Quit = 4,
    }

    private readonly string[] _options = {
        "1. Start Breathing Activity",
        "2. Start Reflecting Activity",
        "3. Start Listing Activity",
        "4. Quit",
    };

    private void Display()
    {
        Console.Clear();
        Console.WriteLine("\nMenu Options:\n");
        foreach (string option in _options)
        {
            Console.WriteLine(option);
        }
        Console.Write("\nSelect a choice from the menu: ");
    }

    public Choice GetChoice()
    {
        Display();
        while (true)
        {
            string input = Console.ReadLine();
            // Sanity check: Make sure the user input is an integer between 1 and 4
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                return (Choice)choice;
            }
            else
            {
                Console.Write("Please type one of the options above (1-4): ");
            }
        }
    }
}