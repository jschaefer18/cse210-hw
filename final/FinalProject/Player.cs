public class Player : GameEntity
{
    protected List<Item> _inventory;
    protected List<Weapon> _weapons;
    protected List<Armor> _armor;

    protected Weapon _equippedWeapon;
    protected Armor _equippedArmor;
    protected int _weaponPower;
    protected int _armorResistance;

    public Player(string name, int points)
        : base(name, 100, 4, 2) // Base stats for Player
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        _inventory = new List<Item>();
        _weapons = new List<Weapon>(); // Initialize Weapons list
        _armor = new List<Armor>();
    }

    public override int CalculateAttack()
    {
        Random random = new Random();
        int additionalDamage = random.Next(0, _attackPower * 5); // Players have a higher damage range
        int damage = _attackPower * 5 + additionalDamage; // Players have a base damage multiplier
        return damage;
    }
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
                    _attackPower++;
                    remainingPoints--;
                    Console.WriteLine($"Attack Power increased to {_attackPower}.");
                    Console.Clear();
                    break;
                case "2":
                    _resistance++;
                    remainingPoints--;
                    Console.WriteLine($"Resistance increased to {_resistance}.");
                    Console.Clear();
                    break;
                case "3":
                    _maxHealth += 10;
                    _currentHealth = _maxHealth; // Update current health to new max health
                    remainingPoints--;
                    Console.WriteLine($"Health increased to {_maxHealth}.");
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    public void Heal()
    {
        _currentHealth = _maxHealth;
    }

    public void AddItemToInventory(Item item)
    {
        if (item is Weapon weapon)
        {
            _weapons.Add(weapon);
            Console.WriteLine($"Added {weapon.GetName()} to weapons section of inventory.");
        }
        else if (item is Armor armor)
        {
            _armor.Add(armor);
            Console.WriteLine($"Added {armor.GetName()} to armor section of inventory.");
        }
        else
        {
            Console.WriteLine($"Unknown item type: {item.GetType().Name}");
        }
    }

    public void ViewInventory()
    {

        Console.WriteLine("Weapons:");
        for (int i = 0; i < _weapons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_weapons[i].GetName()}");
        }

        Console.WriteLine("\nArmor:");
        for (int i = 0; i < _armor.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_armor[i].GetName()}");
        }

        Console.WriteLine("Would you like to equip a weapon? (y/n)");
        string response = Console.ReadLine();
        if (response.ToLower() == "y")
        {
            Console.WriteLine("Enter the index of the weapon you would like to equip:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            EquipWeapon(index);
        }

        Console.WriteLine("Would you like to equip armor? (y/n)");
        response = Console.ReadLine();
        if (response.ToLower() == "y")
        {
            Console.WriteLine("Enter the index of the armor you would like to equip:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            EquipArmor(index);
        }

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
        return;
    }

    private void UnequipWeapon()
    {
        if (_equippedWeapon != null)
        {
            _attackPower -= _weaponPower;
            _weaponPower = 0;
            _equippedWeapon = null;
        }
    }

    private void UnequipArmor()
    {
        if (_equippedArmor != null)
        {
            _resistance -= _armorResistance;
            _armorResistance = 0;
            _equippedArmor = null;
        }
    }

    public void EquipWeapon(int index)
    {
        if (index >= 0 && index < _weapons.Count)
        {
            UnequipWeapon();
            _equippedWeapon = _weapons[index];
            _weaponPower = _weapons[index].GetAttackPower();
            _attackPower += _weaponPower;
            Console.WriteLine($"Equipped {_weapons[index].GetName()} as weapon.");
        }
        else
        {
            Console.WriteLine("Invalid weapon index.");
        }
    }

    public void EquipArmor(int index)
    {
        if (index >= 0 && index < _armor.Count)
        {
            UnequipArmor();
            _equippedArmor = _armor[index];
            _armorResistance = _armor[index].GetResistance();
            _resistance += _armorResistance;
            Console.WriteLine($"Equipped {_armor[index].GetName()} as armor.");
        }
        else
        {
            Console.WriteLine("Invalid armor index.");
        }
    }
}
