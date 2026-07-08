using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int numericGrade))
        {
            Console.WriteLine("Please enter a valid whole number grade percentage.");
            return;
        }

        if (numericGrade < 0 || numericGrade > 100)
        {
            Console.WriteLine("Grade must be between 0 and 100.");
            return;
        }

        string letter;

        if (numericGrade >= 90)
        {
            letter = "A";
        }
        else if (numericGrade >= 80)
        {
            letter = "B";
        }
        else if (numericGrade >= 70)
        {
            letter = "C";
        }
        else if (numericGrade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = string.Empty;

        if (letter == "A")
        {
            if (numericGrade <= 92)
            {
                sign = "-";
            }
        }
        else if (letter != "F")
        {
            int lastDigit = numericGrade % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        if (numericGrade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying; you can do better next time.");
        }
    }
}