public class Armor : Item{
    int resistance;
    public Armor(string name, string description, int resistance) : base(name,description)
    {
        this.resistance = resistance;
    }
    public int GetResistance()
    {
        return resistance;
    }
}