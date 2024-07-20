public class GameEntity{
    protected string _name;
    protected int _currentHealth;
    protected int _maxHealth;
    protected int _attackPower;
    protected int _resistance;

    public GameEntity(string name, int maxHealth, int attackPower, int resistance)
    {
        this._name = name;
        this._maxHealth = maxHealth;
        this._currentHealth = maxHealth;
        this._attackPower = attackPower;
        this._resistance = resistance;
    }

    public virtual int CalculateAttack(){
        Random random = new Random();
        int additionalDamage = random.Next(0, _attackPower * 5);
        int damage = _attackPower * 10 + additionalDamage;
        return damage;

    }

    public void ReceiveDamage(int damage){
        _currentHealth = _currentHealth - damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public int CalculateDamageTaken(int incomingDamage)
    {
        int damageTaken = Math.Max(0, incomingDamage - (_resistance * 10));
        return damageTaken;
    }
    public string GetName()
    {
        return _name;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
        
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetAttackPower()
    {
       return _attackPower;
    }

    public int GetResistance()
    {
        return _resistance;
    }
}