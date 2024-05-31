using System.Data.Common;
using System.Runtime.CompilerServices;

class Word
{
    private String _text;
    private bool _isHidden; 
    private string _encodedText;
    public Word(String text)
    {
        this._text = text;
        _encodedText = _text;
        _isHidden = false;
    }
    

    public void Hide()
    {
        int length = _text.Length;
        _text = "";
        for (int i = 0; i < length; i++)
        {
            _text += "_";
        }
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
        _text = _encodedText;
    }

    public String GetText()
    {
        return _text;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }



}