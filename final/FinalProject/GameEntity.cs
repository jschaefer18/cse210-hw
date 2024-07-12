public class GameEntity{
    protected string name;
    protected int currentHealth;
    protected int maxHealth;
    protected int attackPower;
    protected int resistance;

    public GameEntity(string name, int maxHealth, int attackPower, int resistance)
    {
        this.name = name;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.attackPower = attackPower;
        this.resistance = resistance;
    }

    public int CalculateAttack(){
        Random random = new Random();
        int additionalDamage = random.Next(0, attackPower * 5);
        int damage = attackPower * 10 + additionalDamage;
        return damage;

    }

    public void ReceiveDamage(int damage){
        currentHealth = currentHealth - damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public int CalculateDamageTaken(int incomingDamage)
    {
        int damageTaken = Math.Max(0, incomingDamage - (resistance * 10));
        return damageTaken;
    }
    public string GetName()
    {
        return name;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
        
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetAttackPower()
    {
       return attackPower;
    }

    public int GetResistance()
    {
        return resistance;
    }
}