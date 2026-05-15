//---------------------------------------------------------------------------------
// CSE210 - Program.cs
// Author: Mauricio Reale
//
// Enhancements made in this source code:  
//
//   1) Once a file is loaded, the program will autosave the journal after each new
//      Entry is added, so the user doesn't have to remember to save manually. 
//   2) Each action is implemented as a separate method, making the code more
//      modular and easier to maintain.
//   3) Basic file name validation is performed when loading/saving to ensure the
//      user is working with JSON files, and that the file exists when loading.
//
//--------------------------------------------------------------------------------    

class Program
{
    private static Journal _journal = new Journal();
    private static PromptGenerator _promptGenerator = new PromptGenerator();
    private static Menu _menu = new Menu();
    private static String _fileName;

    private static void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string entryText = Console.ReadLine();
        Entry entry = new Entry(DateTime.Now.ToString("MM/dd/yyyy"), prompt, entryText);
        _journal.AddEntry(entry);
        if (!string.IsNullOrEmpty(_fileName))
        {
            _journal.SaveToFile(_fileName); // Autosave if a file is already loaded or saved to!
        }
    }

    private static void DisplayAll()
    {
        _journal.DisplayAll();
    }

    private static void LoadFromFile()
    {
        Console.Write("What is the file name (Example: journal.json)? ");
        string fileName = Console.ReadLine().ToLower();
        // Sanity check: Make sure the file exists
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"The file '{fileName}' was not found!");
            return;
        }
        // Sanity check: Make sure the file is a JSON file
        if (!fileName.EndsWith(".json"))
        {
            Console.WriteLine($"The file '{fileName}' is not a JSON file! (*.json)");
            return;
        }
        _journal.LoadFromFile(fileName);
        _fileName = fileName;
    }

    private static void SaveToFile()
    {
        Console.Write("What is the file name? (Example: journal.json) ");
        String fileName = Console.ReadLine().ToLower();
        // Sanity check: Make sure the file is a JSON file
        if (!fileName.EndsWith(".json"))
        {
            Console.WriteLine($"The file '{fileName}' is not a JSON file! (*.json)");
            return;
        }
        _journal.SaveToFile(fileName);
        _fileName = fileName;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        while (true)
        {
            int choice = _menu.GetChoice();
            Console.WriteLine("");
            switch (choice)
            {
                case 1:
                    AddEntry();
                    break;
                case 2:
                    DisplayAll();
                    break;
                case 3:
                    LoadFromFile();
                    break;
                case 4:
                    SaveToFile();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return;
            }
        }
    }
}