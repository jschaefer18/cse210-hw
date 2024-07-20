
public class Enemy : GameEntity{
    protected int _experienceDropped;



    public Enemy(int experienceDropped, string name, int maxHealth, int attackPower, int resistance)
        : base(name, maxHealth, attackPower, resistance)
    {
        this._experienceDropped = experienceDropped;
    }

    public int GetExperienceDropped()
    {
        return _experienceDropped;
    }
}