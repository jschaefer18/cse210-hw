
public class Enemy : GameEntity{
    protected int experienceDropped;



    public Enemy(int experienceDropped, string name, int maxHealth, int attackPower, int resistance)
        : base(name, maxHealth, attackPower, resistance)
    {
        this.experienceDropped = experienceDropped;
    }

    public int GetExperienceDropped()
    {
        return experienceDropped;
    }
}