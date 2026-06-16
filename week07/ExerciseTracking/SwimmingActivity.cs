public class SwimmingActivity : Activity
{
    private readonly int _laps; // Number of laps

    public SwimmingActivity(double duration, int laps) : base("Swimming", duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0; // Assuming each lap is 50 meters
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }

    public override double GetSpeed()
    {
        return GetDistance() / (GetDuration() / 60.0);
    }

    
}