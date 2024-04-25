using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        string grade;
        int val = number % 10;
        if (number >= 90){
            grade = "A";
            if (val < 3){
                grade = "A-";
            }
        }
        else if (number >= 80){
            grade = "B";
            if (val >= 7){
                grade = "B+";
            }
            if (val < 3){
                grade = "B-";
            }
        }
        else if (number >= 70){
            grade = "C";
            if (val >= 7){
                grade = "C+";
            }
            if (val < 3){
                grade = "C-";
            }           
        }
        else if (number >= 60){
            grade = "D";
            if (val >= 7){
                grade = "D+";
            }
            if (val < 3){
                grade = "D-";
            }
        }
        else{
            grade = "F";
            }
        
        Console.WriteLine("Your grade is: " + grade);

        if (number >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard and you'll do better next time!");
        }
    }
}
