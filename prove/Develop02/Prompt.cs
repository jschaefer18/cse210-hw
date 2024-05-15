using System;
using System.Collections.Generic;

class Prompt
{
     List<string> prompts = new List<string>
    {
        "What was the highlight of your day?",
        "Describe a challenge you faced today and how you overcame it.",
        "Reflect on a moment of gratitude from today.",
        "Write about a goal you accomplished recently.",
        "Share a random act of kindness you witnessed or performed.",
        "Describe a lesson you learned today.",
        "Write about something that made you laugh today.",
        "Reflect on a skill you're working on improving.",
        "Describe a place you visited or want to visit.",
        "Share a memory from your childhood.",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    private Random rand;

    public Prompt()
    {
        rand = new Random();
    }

    public string GeneratePrompt()
    {
        int randomIndex = rand.Next(0, prompts.Count);
        return prompts[randomIndex];
    }
}
