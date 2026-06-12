//---------------------------------------------------------------------------------
// CSE210 - EternalGoal.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Represents an eternal goal that can be completed infinitely.
//
//--------------------------------------------------------------------------------    

public class EternalGoal : Goal
{
    public EternalGoal(string name = "", string description = "", int points = 0)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
       // Since this goal is eternal, we don't need to do anything when recording an event.
    }

    public override bool IsComplete()
    {
        return false; // Since this goal is eternal, it is never considered complete.
    }

    public override string Serialize()
    {
        return $"{GetTypeName()}|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

    public override void Deserialize(string[] data)
    {
        // Sanity check: Ensure we have the correct number of data fields for deserialization
        if (data.Length != 4)
        {
            throw new ArgumentException("Invalid data for deserializing EternalGoal");
        }
        SetShortName(data[1]);
        SetDescription(data[2]);
        SetPoints(int.Parse(data[3]));
    }

    
}