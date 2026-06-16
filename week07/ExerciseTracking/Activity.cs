public abstract class Activity
{
    private string _name;
    private double _duration; // Duration in minutes
    private string _date;
   
    public Activity(string name, double duration)
    {
        _name = name;
        _duration = duration;
        _date = DateTime.Now.ToString("dd/MM/yyyy");
    }

    protected string GetName()
    {
        return _name;
    }

    protected double GetDuration()
    {
        return _duration;
    }

    protected string GetDate()
    {
        return _date;
    }

    public string GetSummary()
    {
        return $"{GetDate()} {GetName()} ({GetDuration()} min): Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} km/h, Pace: {GetPace():F2} min per km";
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
}