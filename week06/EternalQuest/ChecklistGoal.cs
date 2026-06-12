//---------------------------------------------------------------------------------
// CSE210 - ChecklistGoal.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Represents a checklist goal that can be completed a certain number of times
//      with a bonus awarded upon completing all tasks.
//
//--------------------------------------------------------------------------------    

public class ChecklistGoal : Goal
{
    private int _target;
    private int _amountCompleted;
    private int _bonus;

    public ChecklistGoal(string name = "", string description = "", int points = 0, int target = 0, int bonus = 0)
        : base(name, description, points)
    {
        _target = target;
        _amountCompleted = 0;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override int GetPoints()
    {
        if (IsComplete())
        {
            return base.GetPoints() + _bonus;
        }
        else
        {
            return base.GetPoints();
        }
    }
    
    public override string Serialize()
    {
        return $"{GetTypeName()}|{GetShortName()}|{GetDescription()}|{base.GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public override void Deserialize(string[] data)
    {
        // Sanity check: Ensure we have the correct number of data fields for deserialization
        if (data.Length != 7)
        {
            throw new ArgumentException("Invalid data for deserializing ChecklistGoal");
        }
        SetShortName(data[1]);
        SetDescription(data[2]);
        SetPoints(int.Parse(data[3]));
        _target = int.Parse(data[4]);
        _bonus = int.Parse(data[5]);
        _amountCompleted = int.Parse(data[6]);
    }


}