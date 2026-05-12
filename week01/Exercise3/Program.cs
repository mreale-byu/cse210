using System;

class Program
{
    static void Main(string[] args)
    {

        Random random = new Random();

        int magicNumber = random.Next(1, 101);

        int attempts = 0;

        while (true)
        {

            attempts++;

            Console.Write("What is your guess (1-100)?");

            int guess = int.Parse(Console.ReadLine());

            if (guess == magicNumber)
            {
                Console.WriteLine($"You guessed it after {attempts++} attempts!", attempts);
                attempts = 0;
                String yesNo = "";
                do
                {
                    Console.Write("Do you want to play again (yes/no)? ");
                    yesNo = Console.ReadLine().ToLower();
                  // Make sure the program accepts only "yes" or "no" as user response
                } while (!(yesNo.Equals("yes") || yesNo.Equals("no")));
                // Continue playing ?
                if (yesNo.Equals("yes")) continue; 
                break;
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }

    }
}