public class CyclingActivity : Activity
{
    private readonly double _speed; // Speed in kilometers per hour

    public CyclingActivity(double duration, double speed) : base("Cycling", duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetDuration() / 60.0);
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

   
}