class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endverse;

    public Reference(string book, string chapter, string verse, string endverse)
    {
        this._book = book;
        this._chapter = chapter;
        this._verse = verse;
        this._endverse = endverse;
    }

    public Reference(string book, string chapter, string verse)
    {
        this._book = book;
        this._chapter = chapter;
        this._verse = verse;
    }

    public override string ToString()
    {
        if (_endverse == null)
        {
            return _book + " " + _chapter + ":" + _verse;
        }
        else
        {
            return _book + " " + _chapter + ":" + _verse + "-" + _endverse;
        }
    }


    
}