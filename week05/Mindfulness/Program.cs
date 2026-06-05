//---------------------------------------------------------------------------------
//
// CSE210 - Program.cs
// Title: W05 Mindfulness Program
// Author: Mauricio Reale
//
// Enhancements made:
//    1) Added specialized Menu class to display the menu items, get user input
//       and simplify the main program loop. The Menu class also includes input
//       validation to ensure that only valid choices are made.
//    2) Added specialized classes StringEntry and StringEntryList to handle 
//       unique prompts and questions for the Reflecting and Listing activities.
//    3) Added a customized breathing gauge to the Breathing activity to visually 
//       show the pace of the breathing during the activity.
//    4) Added more prompts and questions to the Reflecting activity.
//    5) Added minDuration and maxDuration attributes to the Activity class to
//       allow for more flexible and sanity-checked durations.
//
//--------------------------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        while (true)
        {
            Menu.Choice choice = menu.GetChoice();
            switch (choice)
            {
                case Menu.Choice.BreathingActivity:
                    new BreathingActivity().Run();
                    break;
                case Menu.Choice.ReflectingActivity:
                    new ReflectingActivity().Run();
                    break;
                case Menu.Choice.ListingActivity:
                    new ListingActivity().Run();
                    break;
                case Menu.Choice.Quit:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    return;
            }
        }
    }
}