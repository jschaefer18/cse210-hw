public class Game
{
    private Player player;
    private List<Enemy> enemies;

    public Game(Player player)
    {
        this.player = player;
        this.enemies = new List<Enemy>();
        // Initialize other game-related setup
    }

    // Method to start the game
    public void Start()
    {



        Console.WriteLine($"Welcome {player.GetName()}!");
        Console.WriteLine("You are going to decide how you would like to destribute 5 points into your character.");
        Console.WriteLine("You can use these points in three stats: attack power, defense, and health.");
        Console.WriteLine("Attack power is going to increae you damage output towards enemies.");
        Console.WriteLine("Defense is going to lessen the damage you take from enemies.");
        Console.WriteLine("Health is going to increase your total health used in the game.");
        Console.WriteLine("You must use all 5 points to continue");
        player.DistributePoints(5);
        Console.WriteLine("You are now ready to start your first battle!");

        StartFirstBattle();
    }

    // Method to start a battle
    private void StartFirstBattle()
    {
        Enemy goblin = new Enemy(20,"Goblin",100,4,2);
 
        while (player.GetCurrentHealth() > 0 && goblin.GetCurrentHealth() > 0)
        {
            // Player's turn to attack
            Console.WriteLine("Press Enter to attack...");
            Console.ReadLine();

            int playerDamage = player.CalculateAttack();
            int goblinDamageTaken = goblin.CalculateDamageTaken(playerDamage);
            goblin.ReceiveDamage(goblinDamageTaken);
            Console.WriteLine($"You dealt {playerDamage} damage to the {goblin.GetName()}. It now has {goblin.GetCurrentHealth()} health left.");

            // Check if goblin is defeated
            if (goblin.GetCurrentHealth() <= 0)
            {
                Console.WriteLine($"You defeated the {goblin.GetName()}!");
                break;
            }

            // Goblin's turn to attack
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            int goblinDamage = goblin.CalculateAttack();
            int playerDamageTaken = player.CalculateDamageTaken(goblinDamage);
            player.ReceiveDamage(playerDamageTaken);
            Console.WriteLine($"The {goblin.GetName()} dealt {goblinDamage} damage to you. You now have {player.GetCurrentHealth()} health left.");

            // Check if player is defeated
            if (player.GetCurrentHealth() <= 0)
            {
                Console.WriteLine("You have been defeated by the goblin. Game Over.");
                break;
            }
        }
    }


}
