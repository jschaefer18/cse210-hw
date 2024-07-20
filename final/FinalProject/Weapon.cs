public class Weapon : Item{
    protected int _attackPower;
    
    public Weapon(string name, string description, int attackPower) : base(name,description)
    {
        this._attackPower = attackPower;
    }
    public int GetAttackPower()
    {
        return _attackPower;
    }



}