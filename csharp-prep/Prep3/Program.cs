using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        Console.WriteLine($"Your number is {number}");
        int numOfGuesses = 0;
        string response = "yes";
        while (response == "yes")
        {
            Console.Write("What is your guess? ");
            string userInput = Console.ReadLine();
            int guess = int.Parse(userInput);

            if (number > guess)
            {
                Console.WriteLine("The magic number is higher!");
                numOfGuesses = numOfGuesses + 1;  
            }
            else if (number < guess)
            {
                Console.WriteLine("The magic number is lower!");
                numOfGuesses = numOfGuesses + 1;  
            }
            else if (number == guess)
            {
                numOfGuesses = numOfGuesses + 1;
                Console.WriteLine($"You guessed the magic number! It was {number} and you did it in {numOfGuesses} guesses.");
                response = "no"; 
            }
            else
            {
                Console.WriteLine($"Error, please try again.");
            }
        }
    }
}
