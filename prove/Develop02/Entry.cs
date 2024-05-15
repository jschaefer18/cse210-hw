using System;

class Entry
{
    public DateTime date;
    public string userEntry;
    public string prompt;

    
    public Entry(DateTime date, string userEntry, string prompt)
    {
        this.date = date;
        this.userEntry = userEntry;
        this.prompt = prompt;
    }

    public void DisplayEntry()
    {
        Console.WriteLine("");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"User Entry: {userEntry}");
        Console.WriteLine("-------------------------------");
    }
}

