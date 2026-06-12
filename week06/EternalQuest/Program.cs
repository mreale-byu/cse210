//---------------------------------------------------------------------------------
// CSE210 - Program.cs
// Author: Mauricio Reale
//
// Enhancements made:
//
//   1) Displays a trophy ASCII art when the user completes a checklist task. 
//      This is a way to achieve some sort of gamification and make the program 
//      more appealing. 
//
//   2) Goal class now contains methods for serialization and deserialization, 
//      allowing goals to be easily saved to and loaded from a file.
//
//   3) New GoalFactory class is responsible for creating goal instances based on
//      the provided data.
//
//   4) GoalManager now includes input validation for file names when saving and
//      loading goals. It also implements specialized methods for input text and
//      numbers, ensuring robust user input handling.
//
//   5) Auto-saving functionality is added to GoalManager, which automatically
//      saves the current opened file whenever a change is made to the goals, so 
//      the user doesn't have to worry about losing progress.
//
//--------------------------------------------------------------------------------    

class Program
{
    static void Main(string[] args)
    {
        new GoalManager().Start();
    }
}