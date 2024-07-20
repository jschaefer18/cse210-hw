public class Game
{
    private Player _player;
    bool _isBanditDefeated = false;
    bool _weaponKey = true;
    bool _isSmallDragonDefeated = false;
    bool _armorKey = true; 

    public Game(Player player)
    {
        this._player = player;
    }

    // Method to start the game
    public void Start()
    {
        Console.WriteLine($"Welcome {_player.GetName()}!");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("You are going to decide how you would like to distribute 5 points into your character.");
        Console.WriteLine("You can use these points in three stats: attack power, defense, and health.");
        Console.WriteLine("Attack power is going to increase your damage output towards enemies.");
        Console.WriteLine("Defense is going to lessen the damage you take from enemies.");
        Console.WriteLine("Health is going to increase your total health used in the game.");
        Console.WriteLine("You must use all 5 points to continue");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();

        _player.DistributePoints(5);

        Console.WriteLine("");
        Console.WriteLine("You are now ready to start your first battle!");
        StartFirstBattle();

    }

    private void StartFirstBattle()
    {
        Enemy _goblin = new Enemy(20, "Goblin", 100, 4, 2);

        while (_player.GetCurrentHealth() > 0 && _goblin.GetCurrentHealth() > 0)
        {
            Console.WriteLine("");
            Console.WriteLine("Press Enter to attack...");
            Console.ReadLine();

            int playerDamage = _player.CalculateAttack();
            int goblinDamageTaken = _goblin.CalculateDamageTaken(playerDamage);
            _goblin.ReceiveDamage(goblinDamageTaken);
            Console.WriteLine($"You dealt {playerDamage} damage to the {_goblin.GetName()}. It now has {_goblin.GetCurrentHealth()} health left.");

            if (_goblin.GetCurrentHealth() <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine($"You defeated the {_goblin.GetName()}!");
                _player.DistributePoints(1);
                Console.WriteLine("You have defeated the goblin and have entered the first village.");
                Console.WriteLine("You can now explore the village and interact with its inhabitants.");
                EnterFirstVillage();
                return; // Exit method after entering village
            }
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            int goblinDamage = _goblin.CalculateAttack();
            int playerDamageTaken = _player.CalculateDamageTaken(goblinDamage);
            _player.ReceiveDamage(playerDamageTaken);
            Console.WriteLine($"The {_goblin.GetName()} dealt {goblinDamage} damage to you. You now have {_player.GetCurrentHealth()} health left.");

            if (_player.GetCurrentHealth() <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("You have been defeated by the goblin. Game Over.");
                return; // Exit method after defeat
            }
        }
    }

    private void EnterFirstVillage()
    {
        Console.WriteLine("");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Visit the blacksmith");
        Console.WriteLine("2. Visit the tavern");
        Console.WriteLine("3. Rest at the inn");
        Console.WriteLine("4. Leave the village");
        Console.WriteLine("5. View Inventory");
        Console.Write("Enter your choice: ");
        string _userInput = Console.ReadLine();

        switch (_userInput)
        {
            case "1":
                Console.Clear();
                VisitBlacksmith();
                break;
            case "2":
                Console.Clear();
                VisitTavern();
                break;
            case "3":
                Console.Clear();
                RestAtInn();
                break;
            case "4":
                Console.Clear();
                StartFourthBattle();
                break;
            case "5":
                Console.Clear();
                _player.ViewInventory();
                EnterFirstVillage();
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                EnterFirstVillage();
                break;
        }
    }

    private void VisitBlacksmith()
    {
        Console.WriteLine("You have visited the blacksmith.");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Talk to blacksmith");
        Console.WriteLine("2. Leave the blacksmith");
        Console.Write("Enter your choice: ");
        Console.WriteLine("");
        string _userInput = Console.ReadLine();

        switch (_userInput)
        {
            case "1":
                NPC _blacksmith = new NPC("Blacksmith", 100, 4, 2, "Welcome to my shop!");
                if (_weaponKey == false){
                    System.Console.WriteLine("The blacksmith has nothing to say to you.");
                    System.Console.WriteLine("Press Enter to leave...");
                    Console.ReadLine();
                    Console.Clear();
                    EnterFirstVillage();
                }

                if (_isBanditDefeated & _weaponKey){

                    System.Console.WriteLine("You have defeated the bandit and have retrieved the blacksmith's supplies.");
                    System.Console.WriteLine("The blacksmith is grateful for your help and offers you a reward(Iron Sword).");
                    Weapon IronSword = new Weapon("Iron Sword", "An Iron Sword given to you by the village blacksmith", 5);
                    _weaponKey = false;
                    _player.AddItemToInventory(IronSword);
                    System.Console.WriteLine("Press Enter to leave...");
                    Console.ReadLine();
                    Console.Clear();
                    EnterFirstVillage();
                }
                Console.WriteLine(_blacksmith.GetDialogue());
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine("Unfortunately, I don't have any items for sale right now.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine("A bandit has been causing trouble in the area and have stolen my supplies. If you could help me retrieve them, I would be able to offer you a reward.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine("Would you like to help the blacksmith?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Enter your choice: ");
                string _helpChoice = Console.ReadLine();
                if (_helpChoice == "1")
                {
                    Console.WriteLine("Thank you! The bandits are hiding in the forest to the east. Please be careful.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    StartSecondBattle();
                    return; // Exit method after starting second battle
                }
                else if (_helpChoice == "2")
                {
                    Console.WriteLine("That's too bad. Let me know if you change your mind.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    EnterFirstVillage();
                    return; // Exit method after returning to village
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    VisitBlacksmith(); // Retry visiting blacksmith
                    return; // Exit method after retrying
                }
            case "2":
                Console.Clear();
                EnterFirstVillage();
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 2.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                VisitBlacksmith(); // Retry visiting blacksmith
                break;
        }
    }



    public void RestAtInn(){
        Console.WriteLine("You have visited the Inn.");
        Console.WriteLine("Would you like to?");
        Console.WriteLine("1. Rest for the night");
        Console.WriteLine("2. Leave the Inn");
        Console.Write("Enter your choice: ");
        string _userInput = Console.ReadLine();
        if(_userInput == "1"){
            _player.Heal();
            Console.WriteLine("You have rested for the night and have been fully healed.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            EnterFirstVillage();
        }
        else if(_userInput == "2"){
            Console.Clear();
            EnterFirstVillage();
        }
        else{
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            RestAtInn();
        }





    }
    public void StartSecondBattle()
    {
        Enemy _bandit = new Enemy(20, "Bandit", 100, 4, 2);

        while (_player.GetCurrentHealth() > 0 && _bandit.GetCurrentHealth() > 0)
        {
            Console.WriteLine("Press Enter to attack...");
            Console.ReadLine();

            int playerDamage = _player.CalculateAttack();
            int banditDamageTaken = _bandit.CalculateDamageTaken(playerDamage);
            _bandit.ReceiveDamage(banditDamageTaken);
            Console.WriteLine($"You dealt {playerDamage} damage to the {_bandit.GetName()}. It now has {_bandit.GetCurrentHealth()} health left.");

            if (_bandit.GetCurrentHealth() <= 0)
            {
                Console.WriteLine($"You defeated the {_bandit.GetName()}!");
                Console.WriteLine("Visit the blacksmith to claim your reward.");
                _isBanditDefeated = true;
                _player.DistributePoints(1);
                EnterFirstVillage();
                return; // Exit method after defeating bandit
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            int banditDamage = _bandit.CalculateAttack();
            int playerDamageTaken = _player.CalculateDamageTaken(banditDamage);
            _player.ReceiveDamage(playerDamageTaken);
            Console.WriteLine($"The {_bandit.GetName()} dealt {banditDamage} damage to you. You now have {_player.GetCurrentHealth()} health left.");

            if (_player.GetCurrentHealth() <= 0)
            {
                Console.WriteLine("You have been defeated by the bandit. Game Over.");
                EnterFirstVillage();
                return; // Exit method after defeat
            }
        }
    }


    public void VisitTavern(){
        Console.WriteLine("You have visited the Tavern.");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Talk to the bartender");
        Console.WriteLine("2. Leave the Tavern");
        Console.Write("Enter your choice: ");
        string _userInput = Console.ReadLine();
        if(_userInput == "1"){
            NPC _bartender = new NPC("Bartender", 100, 4, 2, "Welcome to the tavern!");
            if (_armorKey == false){
                    System.Console.WriteLine("The bartender has nothing to say to you.");
                    System.Console.WriteLine("Press Enter to leave...");
                    Console.ReadLine();
                    Console.Clear();
                    EnterFirstVillage();
                }
            if (_isSmallDragonDefeated & _armorKey){
                System.Console.WriteLine("You have defeated the dragon and have saved the village.");
                System.Console.WriteLine("The bartender is grateful for your help and offers you a reward(Dragon Scale Armor).");
                Armor DragonScaleArmor = new Armor("Dragon Scale Armor", "Armor made from the scales of a dragon", 3);
                _armorKey = false;
                _player.AddItemToInventory(DragonScaleArmor);
                System.Console.WriteLine("Press Enter to leave...");
                Console.ReadLine();
                Console.Clear();
                EnterFirstVillage();
            }
            Console.WriteLine(_bartender.GetDialogue());
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("I have heard rumors of a dragon terrorizing my home village to the north. If you could help us defeat it, I would be able to offer you a reward.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.WriteLine("Would you like to help the bartender?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("Enter your choice: ");
            string helpChoice = Console.ReadLine(); 
            if(helpChoice == "1"){
                Console.WriteLine("Thank you! The dragon is hiding in the mountains to the north. Please be careful.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
                StartThirdBattle();
                return;
            }
            else if(helpChoice == "2"){
                Console.WriteLine("That's too bad. Let me know if you change your mind.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
                EnterFirstVillage();
                return;
            }
            else{
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                VisitTavern();
                return;
            }

        }
        else if(_userInput == "2"){
            Console.Clear();
            EnterFirstVillage();
        }
        else{
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            VisitTavern();
        }
    }

    public void StartThirdBattle(){
        Enemy _dragon = new Enemy(20, "Small Dragon", 150, 7, 4);

        while (_player.GetCurrentHealth() > 0 && _dragon.GetCurrentHealth() > 0)
        {
            Console.WriteLine("Press Enter to attack...");
            Console.ReadLine();

            int _playerDamage = _player.CalculateAttack();
            int _dragonDamageTaken = _dragon.CalculateDamageTaken(_playerDamage);
            _dragon.ReceiveDamage(_dragonDamageTaken);
            Console.WriteLine($"You dealt {_playerDamage} damage to the {_dragon.GetName()}. It now has {_dragon.GetCurrentHealth()} health left.");

            if (_dragon.GetCurrentHealth() <= 0)
            {
                Console.WriteLine($"You defeated the {_dragon.GetName()}!");
                Console.WriteLine("Visit the tavern to claim your reward.");
                _isSmallDragonDefeated = true;
                _player.DistributePoints(3);
                Console.WriteLine("Press Enter to leave...");
                Console.ReadLine();
                Console.Clear();
                EnterFirstVillage();
                return; // Exit method after defeating dragon
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            int _dragonDamage = _dragon.CalculateAttack();
            int _playerDamageTaken = _player.CalculateDamageTaken(_dragonDamage);
            _player.ReceiveDamage(_playerDamageTaken);
            Console.WriteLine($"The {_dragon.GetName()} dealt {_dragonDamage} damage to you. You now have {_player.GetCurrentHealth()} health left.");

            if (_player.GetCurrentHealth() <= 0)
            {
                Console.WriteLine("You have been defeated by the dragon. Game Over.");
                EnterFirstVillage();
                return; // Exit method after defeat
            }
        }
    }



    public void StartFourthBattle()
    {
        Console.WriteLine("You leave the village and start climbing the mountain to the east. You reach the top and see the dragon in the distance.");
        Console.WriteLine("You can feel the dragon's strength and power from here.");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Attack the dragon");
        Console.WriteLine("2. Return to the village");
        Console.Write("Enter your choice: ");
        string _userInput = Console.ReadLine();
        Console.Clear();
        if (_userInput == "1")
        {
            Enemy _dragon = new Enemy(20, "Aura-Filled Dragon", 200, 10, 6);

            while (_player.GetCurrentHealth() > 0 && _dragon.GetCurrentHealth() > 0)
            {
                Console.WriteLine("Press Enter to attack...");
                Console.ReadLine();

                int _playerDamage = _player.CalculateAttack();
                int _dragonDamageTaken = _dragon.CalculateDamageTaken(_playerDamage);
                _dragon.ReceiveDamage(_dragonDamageTaken);
                Console.WriteLine($"You dealt {_playerDamage} damage to the {_dragon.GetName()}. It now has {_dragon.GetCurrentHealth()} health left.");

                if (_dragon.GetCurrentHealth() <= 0)
                {
                    Console.WriteLine($"You defeated the {_dragon.GetName()}!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have completed the game.");
                    Console.WriteLine("Thank you for playing!");
                    Environment.Exit(0); // Exit the game after winning
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                int _dragonDamage = _dragon.CalculateAttack();
                int _playerDamageTaken = _player.CalculateDamageTaken(_dragonDamage);
                _player.ReceiveDamage(_playerDamageTaken);
                Console.WriteLine($"The {_dragon.GetName()} dealt {_dragonDamage} damage to you. You now have {_player.GetCurrentHealth()} health left.");

                if (_player.GetCurrentHealth() <= 0)
                {
                    Console.WriteLine("You have been defeated by the dragon. Game Over.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Thank you for playing!");
                    Environment.Exit(0); // Exit the game after losing
                }
            }
        }
        else if (_userInput == "2")
        {
            Console.Clear();
            EnterFirstVillage();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            StartFourthBattle();
        }
    }

}
