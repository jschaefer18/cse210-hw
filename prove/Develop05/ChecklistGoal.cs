class ChecklistGoal : Goal{
    protected int _required;
    protected int _progress;
    protected int _bonusPoints;


   public ChecklistGoal(String title, string desc, int points, int required, int bonusPoints) : base(title, desc, points){
        _required = required;
        _bonusPoints = bonusPoints;
        _progress = 0;
    }

    public override void RecordEvent(Goal goal, UI ui)
    {
        System.Console.WriteLine(""); 
        if (!goal.GetCompleted())
        {
            _progress++;
            _points = goal.GetPoints();
            ui.AddPoints(_points);

            if (_progress < _required)
            {
                Console.WriteLine($"Congratulations! You have earned {_points} points.");
            }
            else if (_progress == _required)
            {
                _completed = true;
                ui.AddPoints(_bonusPoints);
                Console.WriteLine($"Congratulations! You have earned {_points + _bonusPoints} points.");
            }
        }
        else
        {
            Console.WriteLine($"This goal has already been completed.");
        }
    }

    public int GetRequired(){
        return _required;
    }

    public int GetProgress(){
        return _progress;
    }

    public int GetBonusPoints(){
        return _bonusPoints;
    }


    public void SetProgress(int progress){
        _progress = progress;
    }
}
