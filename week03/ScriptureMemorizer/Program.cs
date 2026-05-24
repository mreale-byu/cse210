//---------------------------------------------------------------------------------
// CSE210 - Program.cs
// Author: Mauricio Reale
//
// Enhancements made to the original Scripture Memorizer specification:  
//
//   1) The new ScriptureLoader class was created to manage a collection of 
//      scriptures, allowing easy retrieval of a random scripture each time the 
//      program runs. This separation of concerns makes the code more organized 
//      and maintainable, as the logic for loading and managing scriptures is 
//      encapsulated in its own class rather than being mixed with the user 
//      interaction and memorization logic in the main program. ScriptureLoader 
//      also makes it easy to add, remove, or modify scriptures in the future 
//      without touching the main program logic.
//
//--------------------------------------------------------------------------------    

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = ScriptureLoader.GetRandomScripture();       
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("quit") || scripture.IsCompletelyHidden()) break;
            scripture.HideRandomWords(); 
        }
    }
}