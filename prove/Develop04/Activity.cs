class Activity{

    protected String _title;
    protected String _description;
    protected int _duration;


    public Activity(String title, String description){
        _title = title;
        _description = description;
        _duration = 1000;
    }
    

    public void LoadingAnimation(int duration){
        
        int delay = 500;
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < duration)
        {
            Console.Write("◴");
            Thread.Sleep(delay);
            Console.Write("\b");
            Console.Write("◷");
            Thread.Sleep(delay);
            Console.Write("\b");
            Console.Write("◶");
            Thread.Sleep(delay);
            Console.Write("\b");
            Console.Write("◵");
            Thread.Sleep(delay);
            Console.Write("\b");
        }
        Console.Write(" \b");
    }


    public void CountDownTimer(int duration)
    {


        int delay = 1000; // Delay in milliseconds

        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Console.Write("\b");
            Thread.Sleep(delay);
        }
        Console.Write(" ");
    }



    public void DisplayStart(){
        string message = $@"Welcome to the {_title} Activity.
        
Description: {_description}";

        
        Console.WriteLine(message);
        Console.WriteLine("");
        Console.WriteLine("How long, in seconds, would you like your session? ");
        int totalDuration = int.Parse(Console.ReadLine());
        _duration = totalDuration;
        Console.Clear();
        Console.WriteLine("Get Ready!");
        LoadingAnimation(5);
        Console.WriteLine("");

    }



    public void DisplayEnd(){
        string messageOne = "Well done!!";
        string messageTwo = $"You have completed another {_duration} seconds of the {_title} Activity.";
        Console.WriteLine("");
        Console.WriteLine(messageOne);
        LoadingAnimation(5);
        Console.WriteLine("");
        Console.WriteLine(messageTwo);
        LoadingAnimation(5);

    }



    

}