
//---------------------------------------------------------------------------------
// CSE210 - Word.cs
// Author: Mauricio Reale
//
// Represents a single word in a scripture, along with its hidden/visible state.
//
//--------------------------------------------------------------------------------    


class Word
{
    private string _text;
    private bool _isHidden; 

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
 
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}