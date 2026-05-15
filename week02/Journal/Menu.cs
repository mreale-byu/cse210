//---------------------------------------------------------------------------------
// CSE210 - Menu.cs
// Author: Mauricio Reale
//
// Enhancements made in this source code:  
//
//   1) Menu is a new class used to simplify the main program. It is responsible
//      for displaying the menu options and getting the user's choice.
//   2) The user input is sanitized to prevent invalid choices.
//
//--------------------------------------------------------------------------------    

class Menu
{
    private readonly String [] _options = {
        "1.Write",
        "2.Display",
        "3.Load",
        "4.Save",
        "5.Quit"
    };

    private void Display()
    {
        Console.WriteLine("\nPlease select one of the following choices:\n");
        foreach (String option in _options)
        {
            Console.WriteLine(option);
        }
        Console.Write("\nWhat would you like to do? ");
    }

    public int GetChoice()
    {
        Display();
        while (true)
        {
            int choice;
            String input = Console.ReadLine();
            // Sanity check: Make sure the user input is an integer between 1 and 5
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 5)
            {
                return choice;
            }
            else
            {
                Console.Write("Please type one of the options above (1-5): ");
            }
        }   
    }
}
    
