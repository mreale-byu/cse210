using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static String PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(String userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}.");
    }
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        String name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, squared);
    }
}