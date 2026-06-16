public class RunningActivity : Activity
{
    private readonly double _distance; // Distance in kilometers

    public RunningActivity(double duration, double distance) : base("Running", duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetPace()
    {
        return GetDuration() / _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (GetDuration() / 60.0);
    }

    
}