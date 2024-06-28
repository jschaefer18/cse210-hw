public class UI{
    private String _fileName;
    private int _totalPoints;
    private List<Goal> _goals;
    private String _rank;



    public UI(){
        _fileName = "goals.txt";
        _totalPoints = 0;
        _goals = new List<Goal>();
    }
    public Goal CreateGoal(){
        while(true){
            Console.WriteLine("The types of goals are: ");
            Console.WriteLine(" 1: Simple Goal");
            Console.WriteLine(" 2: Eternal Goal");
            Console.WriteLine(" 3: Checklist Goal");
            Console.Write("Which type would you like to create: ");
            string goalType = Console.ReadLine();
            if (goalType == "1"){
                Console.Write("Enter the title of the goal: ");
                string simpleTitle = Console.ReadLine();
                Console.Write("Enter the description of the goal: ");
                string simpleDesc = Console.ReadLine();
                Console.Write("Enter the points of the goal: ");
                int simplePoints = Convert.ToInt32(Console.ReadLine());
                SimpleGoal goal = new SimpleGoal(simpleTitle, simpleDesc, simplePoints);
                return goal;
        
            }
            else if (goalType == "2"){
                Console.Write("Enter the title of the goal: ");
                string title = Console.ReadLine();
                Console.Write("Enter the description of the goal: ");
                string desc = Console.ReadLine();
                Console.Write("Enter the points of the goal: ");
                int points = Convert.ToInt32(Console.ReadLine());
                EternalGoal goal = new EternalGoal(title, desc, points);
                return goal;
            }
            else if (goalType == "3"){
                Console.Write("Enter the title of the goal: ");
                string title = Console.ReadLine();
                Console.Write("Enter the description of the goal: ");
                string desc = Console.ReadLine();
                Console.Write("Enter the points of the goal: ");
                int points = Convert.ToInt32(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus: ");
                int required = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the bonus points of the goal: ");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());
                ChecklistGoal goal = new ChecklistGoal(title, desc, points, required, bonusPoints);
                return goal;
            }
            else{
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    public void AddGoal(Goal goal){
        _goals.Add(goal);
    }

    public void ListGoals(){
        String symbol = "";
        int i = 1;
        foreach(Goal goal in _goals){
            if (goal.GetCompleted()){
                symbol = "[X]";
            }
            else{
                symbol = "[ ]";
            }
            if (goal is ChecklistGoal){
                ChecklistGoal cg = (ChecklistGoal)goal;
                Console.WriteLine($"{i}. {symbol} {cg.GetTitle()} ({cg.GetDesc()}) -- Currently completed: {cg.GetProgress()}/{cg.GetRequired()}");
            }
            else{
            Console.WriteLine(i + ". " + symbol + " " +  goal.GetTitle() + " (" + goal.GetDesc() + ")");
            i++;
            }
        }
    }


    public int GetTotalPoints(){
        return _totalPoints;
    }
    
    public List<Goal> GetGoals(){
        return _goals;
    }

    public void RecordEvent(){
        Console.WriteLine("The goals are: ");
        int i = 0;
        foreach (Goal g in _goals){
            Console.WriteLine($"{i+1}. {g.GetTitle()} ");
            i++;
        }
        Console.Write("Which did you complete? ");
        int goalIndex = Convert.ToInt32(Console.ReadLine());
        Goal goal = _goals[goalIndex - 1];
        goal.RecordEvent(goal, this);
    }
    
    public void AddPoints(int points){
        _totalPoints += points;
    }



    public void SaveGoals(){
        using (StreamWriter sw = new StreamWriter(_fileName)){
            String goalType = "";
            foreach(Goal goal in _goals){
                String _title = goal.GetTitle();
                String _desc = goal.GetDesc();
                int _points = goal.GetPoints();
                bool _completed = goal.GetCompleted();
                if (_goals.Count == 0){
                    Console.WriteLine("No goals to save.");
                }
                else if(goal is SimpleGoal){
                    goalType = "SimpleGoal";
                    sw.WriteLine($"{goalType}:{_title},{_desc},{_points},{_completed}");
                }
                else if(goal is EternalGoal){
                    goalType = "EternalGoal";
                    sw.WriteLine($"{goalType}:{_title},{_desc},{_points}");
                }
                else if(goal is ChecklistGoal){
                    ChecklistGoal cg = (ChecklistGoal)goal;
                    int _required = cg.GetRequired();
                    int _progress = cg.GetProgress();
                    int _bonusPoints = cg.GetBonusPoints();
                    goalType = "ChecklistGoal";
                    sw.WriteLine($"{goalType}:{_title},{_desc},{_points},{_bonusPoints},{_required},{_progress}");
                }
            }
        }
    }



    public void LoadGoals()
    {
        // Clear existing goals to reload from file
        _goals.Clear();

        try
        {
            using (StreamReader sr = new StreamReader(_fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string goalType = parts[0];
                        string[] data = parts[1].Split(',');

                        if (goalType == "SimpleGoal" && data.Length >= 4)
                        {
                            string _title = data[0];
                            string _desc = data[1];
                            int _points = int.Parse(data[2]);
                            bool _completed = bool.Parse(data[3]);
                            SimpleGoal goal = new SimpleGoal(_title, _desc, _points, _completed);
                            _goals.Add(goal);
                        }
                        else if (goalType == "EternalGoal" && data.Length >= 3)
                        {
                            string _title = data[0];
                            string _desc = data[1];
                            int _points = int.Parse(data[2]);
                            EternalGoal goal = new EternalGoal(_title, _desc, _points);
                            _goals.Add(goal);
                        }
                        else if (goalType == "ChecklistGoal" && data.Length >= 6)
                        {
                            string _title = data[0];
                            string _desc = data[1];
                            int _points = int.Parse(data[2]);
                            int _bonusPoints = int.Parse(data[3]);
                            int _required = int.Parse(data[4]);
                            int _progress = int.Parse(data[5]);
                            ChecklistGoal goal = new ChecklistGoal(_title, _desc, _points, _required, _bonusPoints);
                            goal.SetProgress(_progress); // Assuming you have a method to set progress
                            _goals.Add(goal);
                        }
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }

    public String GetRank(){
        if (_totalPoints < 100){
            _rank = "Beginner";
            return _rank;
        }
        else if (_totalPoints >= 100 && _totalPoints < 500){
            _rank = "Intermediate";
            return _rank;
        }
        else if (_totalPoints >= 500 && _totalPoints < 1000){
            _rank = "Advanced";
            return _rank;
        }
        else{
            _rank = "Expert";
            return _rank;
        }
    }

}