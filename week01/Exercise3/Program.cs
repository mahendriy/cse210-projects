using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess My Number");
        Random random = new Random();

        while (true)
        {
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("\nI'm thinking of a number between 1 and 100.");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid integer.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} {(guessCount == 1 ? "guess" : "guesses")}!");
                }
            }

            Console.Write("Play again? (yes/no): ");
            string playAgain = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            if (playAgain != "yes")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }
}
