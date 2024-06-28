
using System;
public abstract class Goal{
    protected String _title;
    protected string _desc;
    protected int _points;
    protected bool _completed;
    
    public Goal(string title, string desc, int points)
    {
        _title = title;
        _desc = desc;
        _points = points;
        _completed = false;
    }


    public Goal(string title, string desc, int points, bool completed)
    {
        _title = title;
        _desc = desc;
        _points = points;
        _completed = completed;
    }



    public abstract void RecordEvent(Goal goal, UI ui);


    public string GetTitle(){
        return _title;
    }  

    public string GetDesc(){
        return _desc;
    }


    public int GetPoints(){
        return _points;
    }

    public bool GetCompleted(){
        return _completed;
    }


    public void SetCompleted(bool completed){
        _completed = completed;
    }
}