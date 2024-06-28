public class EternalGoal : Goal{
    public EternalGoal(String title, string desc, int points) : base(title, desc, points){
    }

    public override void RecordEvent(Goal goal, UI ui){
    
        if (goal.GetCompleted() == false){
            _points = goal.GetPoints();
            ui.AddPoints(goal.GetPoints());
            System.Console.WriteLine($"Congratulations! You have earned {_points} points.");
        }
    }



}



