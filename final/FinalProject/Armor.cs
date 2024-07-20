public class Armor : Item{
    protected int _resistance;
    public Armor(string name, string description, int resistance) : base(name,description)
    {
        this._resistance = resistance;
    }
    public int GetResistance()
    {
        return _resistance;
    }

}