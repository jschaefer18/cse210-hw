class BreathingActivity : Activity
{
    public BreathingActivity(string title, string description) : base(title, description)
    {
    }

    public void RunBreathing()
    {
        DisplayStart();
        // Ensure the minimum duration is 5 seconds
        if (_duration < 5)
        {
            _duration = 5;
        }



        // Initial breath which is 5 seconds
        BreathIn(2);
        BreathOut(3);
        int remainingTime = _duration - 5;

        // calculates remaining time in 10 second cycles
        int fullCycles = remainingTime / 10;
        int additionalTime = remainingTime % 10;

        for (int i = 0; i < fullCycles; i++)
        {
            Console.WriteLine("");
            BreathIn(4);
            BreathOut(6);
        }

        if (additionalTime > 5)
        {
            Console.WriteLine("");

            BreathIn(4);
            BreathOut(6);
        }
        else if (additionalTime > 0)
        {
            Console.WriteLine("");

            BreathIn(2);
            BreathOut(3);
        }


        
        DisplayEnd();
        Console.Clear();
    }


    public void BreathIn(int duration)
    {
        Console.Write("Breath in...");
        CountDownTimer(duration);
        Console.WriteLine("");

    }


    public void BreathOut(int duration){

        Console.Write("Now breath out...");
        CountDownTimer(duration);
        Console.WriteLine("");
    }
}

