//---------------------------------------------------------------------------------
// CSE210 - GoalFactory.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Responsible for creating goal instances based on the provided data.
//
//--------------------------------------------------------------------------------    

public class GoalFactory
{
    public static Goal Create(string[] data)
    {
        Goal goal = data[0] switch
        {
            "SimpleGoal" => new SimpleGoal(),
            "EternalGoal" => new EternalGoal(),
            "ChecklistGoal" => new ChecklistGoal(),
            _ => throw new ArgumentException($"Unknown goal type: {data[0]}"),
        };
        goal.Deserialize(data);
        return goal;
    }
}