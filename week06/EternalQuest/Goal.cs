//---------------------------------------------------------------------------------
// CSE210 - Goal.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Represents an abstract goal that must be extended to create specific types
//      of goals and explore the basic concepts of OOP in C# such as inheritance, 
//      polymorphism, and encapsulation.
//
//--------------------------------------------------------------------------------    

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} ({_description})";
    }
    
    public string GetShortName()
    {
        return _shortName;   
    }

    public string GetDescription()
    {
        return _description;
    }
    
    public virtual int GetPoints()
    {
        return _points;
    }

    public string GetTypeName()
    {
        return this.GetType().Name;
    }   
    
    protected void SetShortName(string shortName)
    {
        _shortName = shortName;
    }

    protected void SetDescription(string description)
    {
        _description = description;
    }

    protected void SetPoints(int points)
    {
        _points = points;
    }

    public abstract string Serialize();

    public abstract void Deserialize(string[] data);
    
}