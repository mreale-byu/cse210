//---------------------------------------------------------------------------------
//
// CSE210 - ListingActivity.cs
// Description: Listing activity class that guides the user through a series of
//              prompts to list as many items as possible in a certain topic.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

public class ListingActivity : Activity
{
    private static readonly StringEntryList _prompts = CreatePrompts();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            10, 120)
    { }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt(true);
        List<string> responses = GetListFromUser();
        Console.WriteLine($"\nYou listed {responses.Count} items!");
        WaitMillis(2000);
        DisplayEndingMessage(responses.Count > 0);
    }

    private void DisplayPrompt(bool showCountDown)
    {
        Console.WriteLine("List as many responses you can to the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
        if (showCountDown)
        {
            Console.Write("\nYou may begin in: ");
            ShowCountDown(6);
        }
    }
    
    private string GetRandomPrompt()
    {
         return $"--- {_prompts.GetRandomString()} ---";
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        Console.Clear();
        DisplayPrompt(false);
        StartTime();
        Console.WriteLine();
        while (!IsTimeFinished())
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }

    private static StringEntryList CreatePrompts()
    {
        StringEntryList prompts = new StringEntryList();
        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");
        return prompts;
    }

}