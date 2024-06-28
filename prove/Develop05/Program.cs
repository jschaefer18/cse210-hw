using System;

class Program
{
    static void Main(string[] args)
    {
        UI ui = new UI();
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Your rank is: " + ui.GetRank());
            Console.WriteLine("You have " + ui.GetTotalPoints() + " points.");
            Console.WriteLine("");
            Console.WriteLine("Menu Controls: ");
            Console.WriteLine(" 1: Create New Goals");
            Console.WriteLine(" 2: List Goals");
            Console.WriteLine(" 3: Save Goals");
            Console.WriteLine(" 4: Load Goals");
            Console.WriteLine(" 5: Record Event");
            Console.WriteLine(" 6: Quit");
            Console.Write("Select a choice from menu: ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Goal newGoal = ui.CreateGoal();
                Console.WriteLine("Goal created: " + newGoal.GetTitle());
                ui.AddGoal(newGoal);
            }
            else if (userInput == "2")
            {
                ui.ListGoals();
            }
            else if (userInput == "3")
            {
                ui.SaveGoals();
            }
            else if (userInput == "4")
            {
                ui.LoadGoals();
            }
            else if (userInput == "5")
            {
                ui.RecordEvent();
            }
            else if (userInput == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}