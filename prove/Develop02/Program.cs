using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("Controls:");
            Console.WriteLine("0: Quit the program");
            Console.WriteLine("1: New entry");
            Console.WriteLine("2: Display");
            Console.WriteLine("3: Load");
            Console.WriteLine("4: Save");
            Console.WriteLine("");

            string userInput = Console.ReadLine();
            if (userInput == "0")
            {
                break;
            }
            else if (userInput == "1")
            {
                NewEntry(journal);
            }
            else if (userInput =="2")
            {
                Display(journal);
            }
            else if (userInput == "3")
            {

                Load(journal);
            }
            else if (userInput == "4")
            {
                Save(journal);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void NewEntry(Journal journal)
    {
        Console.WriteLine("");
        Prompt newPrompt = new();
        string prompt = newPrompt.GeneratePrompt();

        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Enter your journal entry:");
        string userEntry = Console.ReadLine();

        Entry newEntry = new(DateTime.Now, userEntry, prompt);
        newEntry.DisplayEntry();
        journal.AddEntry(newEntry);
        

    }

    static void Display(Journal journal)
    {
        journal.DisplayAllEntries(journal._entries);
    }


    static void Save(Journal journal)
    {
        Console.WriteLine("Enter the file path to save the journal entries:");
        string filePath = Console.ReadLine();
        journal.SaveFile(filePath);
    }


    static void Load(Journal journal)
    {
        Console.WriteLine("Enter the file path to load the journal entries:");
        string filePath = Console.ReadLine();
        journal.LoadFile(filePath);
        journal.DisplayAllEntries(journal._entries);
    }

}

