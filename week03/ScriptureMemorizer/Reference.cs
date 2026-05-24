//---------------------------------------------------------------------------------
// CSE210 - Reference.cs
// Author: Mauricio Reale
//
// Represents a scripture reference, including the book, chapter, verse, and 
// optional end verse.
//
//--------------------------------------------------------------------------------    

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;  

    public Reference(string book, int chapter, int verse)    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}{(_endVerse != _verse ? $"-{_endVerse}" : "")}";
    }
}