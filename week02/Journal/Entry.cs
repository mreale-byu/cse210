
//---------------------------------------------------------------------------------
// CSE210 - Entry.cs
// Author: Mauricio Reale
//
// Enhancements made in this source code:  
//
//   1) Properties are provided for accessing the entry's date, prompt, and text
//      without exposing internal state directly.
//
//--------------------------------------------------------------------------------    

class Entry
{
    private String _date;
    private String _promptText;
    private String _entryText;

    public Entry(String date,  String promptText, String entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptText}" );
        Console.WriteLine($"{_entryText}");
    }

    public string Date
    {
        get => _date;
    }

    public string PromptText
    {
        get => _promptText;
    }

    public string EntryText
    {
        get => _entryText;  
    }
}