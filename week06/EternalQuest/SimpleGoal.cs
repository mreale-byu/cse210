//---------------------------------------------------------------------------------
// CSE210 - SimpleGoal.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Represents a simple goal that can be completed once.
//
//--------------------------------------------------------------------------------    

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name = "", string description = "", int points = 0)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string Serialize()
    {
        return $"{GetTypeName()}|{GetShortName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}";
    }

    public override void Deserialize(string[] data)
    {
        if (data.Length != 5)
        {
            throw new ArgumentException("Invalid data for deserializing SimpleGoal");
        }

        // We can ignore the type since we already know we're deserializing a SimpleGoal
        SetShortName(data[1]);
        SetDescription(data[2]);
        SetPoints(int.Parse(data[3]));
        _isComplete = bool.Parse(data[4]);
    }

    
}