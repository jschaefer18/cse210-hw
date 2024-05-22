using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public string _filePath;
    public List<Entry> _entries = new List<Entry>();

public void LoadFile(string _filePath)
{
    _entries.Clear();

    using (StreamReader reader = new StreamReader(_filePath))
    {
        while (!reader.EndOfStream)
        {
            // Read the date line
            string dateStr = reader.ReadLine();
            // Skip "Date: " and parse the remaining string as a date
            if (DateTime.TryParse(dateStr.Substring(6), out DateTime date))
            {
                string prompt = reader.ReadLine();
                string userEntry = reader.ReadLine();
                // Skip the separator line
                reader.ReadLine();

                Entry entry = new Entry(date, userEntry, prompt);
                _entries.Add(entry);
            }
            else
            {
                Console.WriteLine($"Invalid date format: {dateStr}");
            }
        }
    }

    Console.WriteLine("Journal loaded successfully.");
}




    public void SaveFile(string _filePath)
    {
        
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
    
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"Date: {entry.date}");
                writer.WriteLine($"Prompt: {entry.prompt}");
                writer.WriteLine($"User Entry: {entry.userEntry}");
                writer.WriteLine("-------------------------------");
            }
        }

        Console.WriteLine("Journal entries have been saved to the file.");
    }


    public List<Entry> AddEntry(Entry entry)
    {
        _entries.Add(entry);
        return _entries;
    }
    public void DisplayAllEntries(List<Entry> entries)
    {
        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }



}