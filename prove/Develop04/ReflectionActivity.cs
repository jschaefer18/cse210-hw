class ReflectionActivity : Activity
{

    private List<string> _prompts = new List<string>
        {
            "I stood up for a colleague at work when they were being unfairly criticized during a meeting.",
            "I completed a marathon despite facing numerous physical challenges and doubts about my ability.",
            "I volunteered at a local food bank, helping to distribute meals to families in need.",
            "I donated a significant portion of my savings to a charity that supports underprivileged children, without expecting anything in return."
        };
    private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

    public ReflectionActivity(string title, string description) : base(title, description)
    {
    }

    public void RunReflection()
    {
        DisplayStart();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("");
        Console.WriteLine($"--- {GetPrompt()} ---");
        Console.WriteLine("");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("You may begin in: ");
        CountDownTimer(5);
        Console.Clear();

        int fullCycles = _duration / 15;

        for (int i = 0; i < fullCycles; i++){
            Console.Write("> " + GetQuestion());
            LoadingAnimation(15);
            Console.WriteLine("");
        }
        DisplayEnd();
        Console.Clear();
    }
    private string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }


    private string GetQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }



}