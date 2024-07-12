class NPC : GameEntity{
    protected string dialiogue;
    Item heldItem;
    public NPC(string name, int maxHealth, int attackPower, int resistance, string dialiogue) : base(name, maxHealth, attackPower, resistance)
    {
        this.dialiogue = dialiogue;
    }



    public string GetDialogue()
    {
        return dialiogue;
    }



    public void GiveItem(Item item)
    {
        heldItem = item;
    }
}