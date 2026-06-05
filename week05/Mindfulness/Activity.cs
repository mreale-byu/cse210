
//---------------------------------------------------------------------------------
//
// CSE210 - Activity.cs
// Description: Base class that provides common functionality for all time bounded
//              activities.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------
using System.Diagnostics;

public class Activity
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _minDuration;
    private readonly int _maxDuration;  
    private int _duration;
    private long _startTime;
    

    public Activity(string name, string description, int minDuration, int maxDuration)
    {
        _name = name;
        _description = description;
        _minDuration = minDuration;
        _maxDuration = maxDuration;
        _duration = 0;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}\n");
        PromptDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner();
        Console.Clear();
    }

    protected void DisplayEndingMessage(bool success)
    {
        Console.Clear();
        string feedbackMsg = success ? "Well done!" : "You may be better next time!";
        Console.WriteLine($"{feedbackMsg}");
        ShowSpinner();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner();
    }

    protected void WaitMillis(int milliseconds)
    {
        Thread.Sleep(milliseconds);
    }

    protected void ShowSpinner(int seconds = 4)
    {
        string[] _frames = ["|", "/", "-", "\\"];
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(_frames[i % _frames.Length]);
            WaitMillis(250); // One frame each 1/4 of a second 
            Console.Write("\b");
        }
        Console.Write(" ");
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            WaitMillis(1000); // 1 second
            Console.Write("\b \b");
        }
    }

    private void PromptDuration()
    {
        Console.Write($"> How long would you like for your session? (between {_minDuration} and {_maxDuration} seconds): ");
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration) && duration >= _minDuration && duration <= _maxDuration)
            {
                _duration = duration;
                break;
            }
            else
            {
                Console.Write($"> Please enter a valid duration between {_minDuration} and {_maxDuration} seconds: ");
            }
        }
    }

    protected void StartTime()
    {
        _startTime = Stopwatch.GetTimestamp();
    }

    protected bool IsTimeFinished()
    {
        return Stopwatch.GetElapsedTime(_startTime).TotalSeconds >= _duration;
    }

}