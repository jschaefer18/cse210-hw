using System;

class Program
{
    static void Main(string[] args)
    {
        string greeting = "Hello, Sandbox!";
        Console.WriteLine(greeting);
        while(true)
        {
            int delay = 250;
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);
            Console.Write("|\b");
            Thread.Sleep(delay);

        }
    }
}