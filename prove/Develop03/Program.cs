using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", "3", "16");
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have everlasting life.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{reference} {scripture.PrintWords()}");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                return;
            }
            scripture.HideWords();
            if (scripture.IsCompletelyHidden() == true)
            {
                Console.Clear();
                Console.WriteLine($"{reference} {scripture.PrintWords()}");
                Console.WriteLine("");
                Guess();
                return;
            }
        }
    }

    public static void Guess()
    {
        Console.WriteLine("Write down your guess of the completed verse: ");
        string guess = Console.ReadLine();
        if (guess == "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have everlasting life.")
        {
            Console.WriteLine("Congratulations! You guessed the verse correctly!");
        }
        else
        {
            Console.WriteLine("Sorry, that is not the correct verse.");
        }
    }
}