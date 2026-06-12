//---------------------------------------------------------------------------------
// CSE210 - GoalManager.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Manages the creation, listing, saving, loading, and recording of goals.
//      This class encapsulates the main functionality of the goal-tracking
//      application and interacts with the user through the console interface.
//
//--------------------------------------------------------------------------------    

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _fileName;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your total score is >> {_score} << points.\n");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Menu Options:\n");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit\n");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:\n");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count++}. {goal.GetShortName()}");
        }
    }

    private void ListGoalsDetails()
    {
        Console.Clear();
        // Sanity check:  Avoid listing when there are no goals
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to list. Please create a goal or load from file first.\n");
            return;
        }
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count++}. {goal.GetDetailsString()}");
        }
        Console.WriteLine();
    }

    private void CreateGoal()
    {
        Console.Clear();
        int goal = GetGoalTypeChoice();
        string name = GetInputAsText("> What is the name of your goal? ", 1, 50);
        string description = GetInputAsText("> What is a short description of it? ", 1, 150);
        int points = GetInputAsNumber("> What is the amount of points associated with this goal (1-1000)? ", 1, 1000); 
        switch (goal)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                int target = GetInputAsNumber("> How many times does this goal need to be accomplished for a bonus? ", 1, 1000);
                int bonus = GetInputAsNumber("> What is the bonus for accomplishing it that many times? ", 1, 1000);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
        AutoSave();
        Console.Clear();
    }

    private void SaveGoals()
    {
        Console.Clear();
        // Sanity check: Avoid saving when there are no goals
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to save. Please create a goal first.\n");
            return;
        }
        _fileName = GetInputAsFileName("> What is the name of the file to save to (Ex: goals.txt)? ", 5, ".txt");
        SaveToFile(_fileName);
        Console.Clear();
    }

    private void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    private void AutoSave()
    {
        if (!string.IsNullOrEmpty(_fileName) && _goals.Count > 0)
        {
            SaveToFile(_fileName);
        }
    }

    private void LoadGoals()
    {
        Console.Clear();
        string fileName = GetInputAsFileName("> What is the name of the file to load from (Ex: goals.txt)? ", 5, ".txt");
        // Sanity check: Avoid loading if the file doesn't exist
        if (!File.Exists(fileName))
        {
           Console.Clear();
           Console.Write($"File '{fileName}' does not exist. Please check the file name and try again.\n\n");
           return;
       }
        _goals.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            _score = int.Parse(reader.ReadLine() ?? "0");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                _goals.Add(GoalFactory.Create(data));
            }
        }
        _fileName = fileName;
        Console.Clear();
    }

    private void RecordEvent()
    {
        Console.Clear();
        // Sanity check: Avoid recording an event when there are no goals
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Please create a goal or load from file first.\n");
            return;
        }
        ListGoalNames();
        Console.WriteLine();
        int choice = GetInputAsNumber("> Which goal did you accomplish? ", 1, _goals.Count);
        Console.Clear();
        Goal goal = _goals[choice - 1];
        // Sanity check: Avoid recording an event for a goal that's already complete
        if (!goal.IsComplete())
        {
            goal.RecordEvent();
            _score += goal.GetPoints();
            Console.WriteLine($"\nCongratulations! You've earned {goal.GetPoints()} points.\n");
            // Special case when completing a checklist goal
            if (goal.IsComplete() && goal is ChecklistGoal)
            {
                Trophy.Display();
                Console.WriteLine($"\nYou also completed the goal '{goal.GetShortName()}'!\n");
            }
            AutoSave();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\nThe goal '{goal.GetShortName()}' is already complete! No points awarded.\n");
        }
    }

    private int GetInputAsNumber(string prompt, int minValue, int maxValue)
    {
        Console.Write(prompt);
        while(true)
        {
            // Sanity check: Ensure the input is a valid integer within the specified bounds
            if (int.TryParse(Console.ReadLine().Trim(), out int number) && number >= minValue && number <= maxValue)
            {
                return number;
            }
            Console.Write($"> Invalid input. Please enter a number between {minValue} and {maxValue}: ");
        }
    }

    private string GetInputAsText(string prompt, int minLength, int maxLength)
    {
        Console.Write(prompt);
        while(true)
        {
            string input = Console.ReadLine().Trim();
            // Sanity check: Ensure the input does not contain the '|' character used as delimiter in our file format
            if (input.Contains('|'))
            {
                Console.Write($"> Invalid input. Text should not contain the '|' character: ");
                continue;
            }
            // Sanity check: Ensure the input length is within the specified bounds
            if (input.Length >= minLength && input.Length <= maxLength)
            {
                return input;
            }
            Console.Write($"> Invalid input. Text length should be between {minLength} and {maxLength} characters: ");
        }
    }

    private string GetInputAsFileName(string prompt, int minLength, string extension)
    {
        Console.Write(prompt);
        while(true)
        {
            string input = Console.ReadLine().Trim().ToLower();
            // Sanity check: Ensure the minimal length for file name
            if (input.Length < minLength)
            {
                Console.Write($"> Invalid input. File name should be at least {minLength} characters long: ");
                continue;
            }
            // Sanity check: Ensure the file name ends with the correct extension
            if (!input.EndsWith(extension))
            {
                Console.Write($"> Invalid input. File name should end with '{extension}': ");
                continue;
            }
            return input;
        }
    }

    private string GetInputAsYesNo(string prompt)
    {
        Console.Write(prompt);
        while(true)
        {
            string input = Console.ReadLine().Trim().ToLower();
            // Sanity check: Ensure the input is either 'yes' or 'no'
            if (input.Equals("yes") || input.Equals("no"))
            {
                return input;
            }
            Console.Write($"> Invalid input. Please answer 'yes' or 'no': ");
        }
    }

    private int GetGoalTypeChoice()
    {
        Console.WriteLine("The types of Goals are:\n");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal\n");
        return GetInputAsNumber("> Which type of goal would you like to create? ", 1, 3);
    }

    private void Finish()
    {
        Console.Clear();
        if (string.IsNullOrEmpty(_fileName) && _goals.Count > 0)
        {
            string input = GetInputAsYesNo("You have unsaved goals. Would you like to save before exiting (yes/no)? ");
            if (input.Equals("yes"))
            {
                Console.Clear();
                _fileName = GetInputAsFileName("> What is the name of the file to save to (Ex: goals.txt)? ", 5, ".txt");
                SaveToFile(_fileName);
            }
        }
        Console.Clear();
        Console.WriteLine("Good bye!\n");
    }

    public void Start()
    {
        Console.Clear();

        while (true)
        {
            DisplayPlayerInfo();
            DisplayMenu();

            switch (GetInputAsNumber("> Select a choice from the menu: ", 1, 6))
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalsDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Finish();
                    return;
            }
        }
    }
}