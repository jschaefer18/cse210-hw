class NPC : GameEntity{
    protected string dialiogue;
    public NPC(string name, int maxHealth, int attackPower, int resistance, string dialiogue) : base(name, maxHealth, attackPower, resistance)
    {
        this.dialiogue = dialiogue;
    }



    public string GetDialogue()
    {
        return dialiogue;
    }



}