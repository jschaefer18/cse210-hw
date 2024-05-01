using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number: ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        return number;
    }

    static int SquareNumber(int num)
    {
        return num * num;
    }

    static void DisplayResult(int sqrt,string name)
    {
        Console.WriteLine($"Hi {name}, your favorite number squared is {sqrt}.");
    }
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int sqrt = SquareNumber(number);
        DisplayResult(sqrt,name);


    }
}