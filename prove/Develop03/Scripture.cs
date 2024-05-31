class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private string _text;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
    public void HideWords()
    {
        int length = _words.Count;
        Random random = new Random();
        int count = 0;
        int wordsToHide = 3;


        int unhiddenWordsCount = _words.Count(word => !word.IsHidden());

        
        if (unhiddenWordsCount < 3)
        {
            wordsToHide = unhiddenWordsCount;
        }

        while (count < wordsToHide)
        {
            int randomIndex = random.Next(0, length);
            if (_words[randomIndex].IsHidden())
            {
                continue;
            }
            _words[randomIndex].Hide();
            count++;
        }
    }

    public string PrintWords()
    {
        string result = "";
        foreach (Word word in _words)
        {
            result += word.GetText() + " ";
        }
        return result;
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

}