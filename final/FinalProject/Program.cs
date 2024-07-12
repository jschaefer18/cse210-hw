using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the name of your character? ");
        String name = Console.ReadLine();
        Player player = new Player(name, 5);
        Game game = new Game(player);
        game.Start();

        


    }
}