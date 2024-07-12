public class Weapon : Item{
    int attackPower;
    public Weapon(string name, string description, int attackPower) : base(name,description)
    {
        this.attackPower = attackPower;
    }
    public int GetAttackPower()
    {
        return attackPower;
    }
}