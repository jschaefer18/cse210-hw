public class SimpleGoal : Goal{
    public SimpleGoal(String title, string desc, int points) : base(title, desc, points){
    }


    public SimpleGoal(String title, string desc, int points, bool completed) : base(title, desc, points, completed){
    }




    public override void RecordEvent(Goal goal, UI ui){
        if (goal.GetCompleted() == false){
            _completed = true;
            _points = goal.GetPoints();
            ui.AddPoints(goal.GetPoints());
            System.Console.WriteLine($"Congratulations! You have earned {_points} points.");
        }
        else{
            System.Console.WriteLine("This goal has already been completed.");
        }
    }
    
}

