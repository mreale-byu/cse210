using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;
        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
            else
               break; 
        }
        Console.WriteLine($"The sum is: {numbers.Sum()}.") ;
        Console.WriteLine($"The average is: {numbers.Average()}.");
        Console.WriteLine($"The largest number is: {numbers.Max()}.");
        int small = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        // Only makes sense showing this if the there are positive numbers in the list
        if (small > 0)
        {
            Console.WriteLine($"The smallest positive number is: {small}.");
        }
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
  
    }
}