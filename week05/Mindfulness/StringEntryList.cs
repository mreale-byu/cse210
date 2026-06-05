//---------------------------------------------------------------------------------
//
// CSE210 - StringEntryList.cs
// Description: Manages a list of StringEntry objects and provides methods to 
//              interact with them. Implements functionality to get unique, random
//              entries and reset their "used" status.
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

public class StringEntryList
{
    private List<StringEntry> _entries;

    public StringEntryList()
    {
        _entries = new List<StringEntry>();
    }

    public void Add(string value)
    {
        _entries.Add(new StringEntry(value));
    }

    public string GetRandomString()
    {
        List<StringEntry> entries = GetAvailableEntries();
        StringEntry entry = entries[new Random().Next(0, entries.Count)];
        entry.SetUsed(true);
        return entry.ToString();
    }

    public int Count
    {
        get { return _entries.Count; }
    }

    public void ResetUsed()
    {
        foreach (StringEntry entry in _entries)
        {
            entry.SetUsed(false);
        }
    }

    private List<StringEntry> GetAvailableEntries()
    {
        List<StringEntry> entries = new List<StringEntry>();
        foreach (StringEntry entry in _entries)
        {
            if (!entry.IsUsed())
            {
                entries.Add(entry);
            }
        }
        if (entries.Count == 0) 
        {
             // if all entries have been used, reset and make everything available again.
            ResetUsed();
            return _entries;
        }
        return entries;
    }
  
    
}