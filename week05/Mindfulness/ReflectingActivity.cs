//---------------------------------------------------------------------------------
//
// CSE210 - ReflectingActivity.cs
// Description: Reflecting activity class that guides the user through a series of
//              prompts to reflect on past experiences and personal growth.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

public class ReflectingActivity : Activity
{
    private static readonly StringEntryList _prompts = CreatePrompts();
    private static readonly StringEntryList _questions = CreateQuestions();

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            10, 120)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        _questions.ResetUsed();
        DisplayQuestions();
        DisplayEndingMessage(true);
    }

    private string GetRandomPrompt()
    {
        return $"--- {_prompts.GetRandomString()} ---";
    }

    private string GetRandomQuestion()
    {
        return $"> {_questions.GetRandomString()}";
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(6);
        Console.Clear();
        StartTime();
        while (!IsTimeFinished())
        {
            Console.Write($"{GetRandomQuestion()}");
            ShowSpinner(10);
            Console.Write("\n");
        }
    }

    private static StringEntryList CreatePrompts()
    {
        StringEntryList prompts = new StringEntryList();
        prompts.Add("Think of a time when you stood up for someone else.");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");
        prompts.Add("Think of a time when you showed courage, even though you were afraid.");
        prompts.Add("Think of a time when you made a sacrifice to help someone else succeed.");
        prompts.Add("Think of a time when you persevered through a challenge that seemed impossible at first.");
        prompts.Add("Think of a time when you chose to do what was right, even when it was unpopular or inconvenient.");
        prompts.Add("Think of a time when your actions made a positive difference in another person's life.");
        return prompts;
    }

    private static StringEntryList CreateQuestions()
    {
        StringEntryList questions = new StringEntryList();
        questions.Add("Why was this experience meaningful to you?");
        questions.Add("Have you ever done anything like this before?");
        questions.Add("How did you get started?");
        questions.Add("How did you feel when it was complete?");
        questions.Add("What made this time different than other times when you were not as successful?");
        questions.Add("What is your favorite thing about this experience?");
        questions.Add("What could you learn from this experience that applies to other situations?");
        questions.Add("What did you learn about yourself through this experience?");
        questions.Add("How can you keep this experience in mind in the future?");
        questions.Add("Do you feel more prepared to handle similar situations in the future?");
        questions.Add("What strengths did you display in this experience?");
        questions.Add("What was the most important lesson you learned from this experience?");
        return questions;
    }
}