//---------------------------------------------------------------------------------
//
// CSE210 - StringEntry.cs
// Description: StringEntry class that represents a single string entry with a
//              "used" flag.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

public class StringEntry
{
    private string _value;
    
    private bool _used;
        
    public StringEntry(string value)
    {
        _value = value;
        _used = false;
    }

    public bool IsUsed()
    {
        return _used;
    }

    public void SetUsed(bool used)
    {
        _used = used;
    }

    public override string ToString()
    {
        return _value;
    }
}