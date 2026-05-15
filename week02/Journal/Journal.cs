//---------------------------------------------------------------------------------
// CSE210 - Journal.cs
// Author: Mauricio Reale
//
// Enhancements made in this source code:  
//
//   1) File is saved/loaded in JSON format. This is more solid than custom format.
//   2) User is informed if there are no journal entries to display
//
//--------------------------------------------------------------------------------    

using System.Text.Json;

class Journal
{
    private List<Entry> _entries = [];

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display!");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
      string json = File.ReadAllText(filename);
      _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? [];
    }
}