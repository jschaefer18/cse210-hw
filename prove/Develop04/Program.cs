using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Controls:");
            Console.WriteLine("1: Start breathing activity");
            Console.WriteLine("2: Start reflecting actvity");
            Console.WriteLine("3: Start listing activity");
            Console.WriteLine("4: Quit");
            Console.WriteLine("");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {   BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathingActivity.RunBreathing();        

            }
            else if (userInput =="2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflectionActivity.RunReflection();
            }
            else if (userInput == "3")
            {
                ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                listingActivity.RunListing();
            }
            else if (userInput == "4")
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
