using System;

class Program
{
    static readonly int MINIMAL_PASSING_GRADE = 70;

    static Boolean EndsWith(int grade, int number)
    {
        return Math.Abs(grade) % 10 == number;
    }

    static void Main(string[] args)
    {
        Console.Write("What is your current grade percentage? ");
        
        string answer = Console.ReadLine();
        string modifier = "";

        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (letter != "F")
        {
            if (EndsWith(percent, 7) || EndsWith(percent, 8) || EndsWith(percent, 9))
            {
                modifier = letter == "A" ? "" : "+"; 
            }
            else if (EndsWith(percent, 0) || EndsWith(percent, 1) || EndsWith(percent, 2) || EndsWith(percent, 3) || EndsWith(percent, 4))
            {
                modifier = "-";
            }
        }

        letter += modifier;    

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= MINIMAL_PASSING_GRADE)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("You did not pass, but keep striving. You can do it!");
        }
    }
}