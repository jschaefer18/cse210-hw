class ListingActivity : Activity
{


    private List<string> _questions = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected int count = 0;
    public ListingActivity(string title, string description) : base(title, description)
    {
    }

    public void RunListing()
    {
        DisplayStart();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {getQuestion()} ---");
        Console.Write("You may begin in: ");
        CountDownTimer(5);
        Console.WriteLine("");
        



        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            count++;
        }


        Console.WriteLine("");
        Console.WriteLine($"You listed {count} items!");
        Console.WriteLine("");
        DisplayEnd();
        Console.Clear();
        Console.Clear();
        Console.Clear();
    }
    private string getQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }




}