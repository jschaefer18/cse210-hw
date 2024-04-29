using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        bool act = true;
        while (act)
        {
            Console.WriteLine("Enter number: ");
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);
            if (userNumber == 0)
            {
                act = false;
            }
            else
            {
                numbers.Add(userNumber);
            }
        }
        int total = 0;
        int count = 0;
        int max = numbers[0];
        foreach (int num in numbers)
        {
            total += num;
            count += 1;
            if (num>max){
                max = num;
            }
            
        }
        Console.WriteLine($"Sum: {total}");
        float average = ((float)total) / count;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The max is: {max}");
    }
}

