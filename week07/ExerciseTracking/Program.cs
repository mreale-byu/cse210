class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Activity> activities = new List<Activity>();
        activities.Add(new RunningActivity(30, 4.8)); // 30 minutes, 4.8 km
        activities.Add(new CyclingActivity(60, 20)); // 60 minutes, 20 km/h
        activities.Add(new SwimmingActivity(60, 30)); // 60 minutes, 30 laps
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine();
    }
}