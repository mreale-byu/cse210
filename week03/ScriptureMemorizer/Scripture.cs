//---------------------------------------------------------------------------------
// CSE210 - Scripture.cs
// Author: Mauricio Reale
//
// Represents a scripture, including its reference and the words that make up the
// text. There are some private helper methods to manage the hiding of words, and
// enforce single responsibility.
//
//--------------------------------------------------------------------------------    

class Scripture
{
    private readonly Reference _reference;

    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = [];
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        int count = new Random().Next(2, 4); // hides just a few words at a time.
        for (int i = 0; i < count; i++)
        {
            if (!HideSingleWord()) break; // stop trying to hide more words if there are no more visible words to hide.
        }
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    private List<Word> GetVisibleWords()
    {
        List<Word> visibleWords = [];
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }
        return visibleWords;
    }

    private bool HideSingleWord()
    {
        List<Word> visibleWords = GetVisibleWords(); 
        if (visibleWords.Count > 0)
        {
            Word wordToHide = visibleWords[new Random().Next(0, visibleWords.Count)];
            wordToHide.Hide();
            return true;    
        }
        return false; // no more visible words to hide.
    }

}