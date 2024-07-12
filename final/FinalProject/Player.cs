
public class Player : GameEntity
{


    public List<Item> Inventory;
    public int Experience;
    public int Level;
    public Player(string name, int points)
        : base(name, 100, 4, 2) // Base stats for Player
    {
        maxHealth = 100;
    }

    // Method to distribute additional points based on player choice
    public void DistributePoints(int points)
    {
        int remainingPoints = points;

        Console.WriteLine($"You have {remainingPoints} points to distribute.");

        while (remainingPoints > 0)
        {
            Console.WriteLine($"Remaining points: {remainingPoints}");
            Console.WriteLine("Choose where to allocate points:");
            Console.WriteLine("1. Attack Power");
            Console.WriteLine("2. Defense (Resistance)");
            Console.WriteLine("3. Health");
            Console.Write("Enter your choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    attackPower++;
                    remainingPoints--;
                    Console.WriteLine($"Attack Power increased to {attackPower}.");
                    break;
                case "2":
                    resistance++;
                    remainingPoints--;
                    Console.WriteLine($"Resistance increased to {resistance}.");
                    break;
                case "3":
                    maxHealth += 10;
                    remainingPoints--;
                    Console.WriteLine($"Health increased to {maxHealth}.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }
        }
    }
}
