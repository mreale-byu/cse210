//---------------------------------------------------------------------------------
//
// CSE210 - BreathingActivity.cs
// Description: Breathing activity class that guides the user through a series of
//              timed breaths in and out.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
               10, 300) {
    }

    private string[] gauge = ["[", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ",
                                   " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "]"];
    
    private void DisplayBreathingIn(int seconds)
    {
        Console.Clear();
        Console.WriteLine("Breathe in -->");
        for (int i = 1; i <= 20; i++)
        {
            gauge[i] = "=";
            Console.Write("\r" + string.Join("", gauge));
            WaitMillis(seconds * 1000 / 20); 
        }
    }

    private void DisplayBreathingOut(int seconds)
    {
        Console.Clear();
        Console.WriteLine("Breathe out <--");
        for (int i = 20; i >= 1; i--)
        {
            gauge[i] = " ";
            Console.Write("\r" + string.Join("", gauge));
            WaitMillis(seconds * 1000 / 20); 
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        StartTime();
        while (!IsTimeFinished())
        {
            DisplayBreathingIn(2);
            WaitMillis(2000); 
            DisplayBreathingOut(4);
            WaitMillis(2000);
        }
        DisplayEndingMessage(true);
    }
}