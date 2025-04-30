using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Media;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Monster goblin;
        private Monster skeleton;
        private Monster ogre;
        private Monster dragon;
        private Room startingRoom;
        private Room roomA;
        private Room roomB;
        private Room roomC;
        private Room roomD;
        private Room roomE;
        private Room finalRoom;
        private Inventory playerInventory;
        private Inventory monsterInventory;
        private Heals healthPotion;
        private Melee sword;
        private Melee axe;
        private LongRange fireBall;
        private LongRange bowAndArrow;
        private Test test;
        private Statistics statistics;
        bool skeletonDead = false;
        bool goblinDead = false;
        bool ogreDead = false;
        bool dragonDead = false;

        public Game()
        {
            test = new Test();

            bool inOptions = true;

            while (inOptions = true)
            {
                try
                {
                    Console.WriteLine("Please enter a username: ");
                    string playerUsername = Console.ReadLine();
                    player = new Player(playerUsername, 100, 0, 0, 0, 0);

                    if (playerUsername.Length == 0)
                    {
                        Debug.Assert(playerUsername.Length != 0, test.TestMethod());
                        throw new ArgumentNullException("No name entered, please try again");
                    }

                    if (playerUsername.Length > 0)
                    {
                        break;
                    }
                }

                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Welcome {player.Name}");
            startingRoom = new Room("Starting Room", false, false, "starting room", "A cold and dark empty room",
                "There are no enemies in this room");
            roomA = new Room("Room A", false, false, "combat room", "A room covered in bones and skulls",
                "There is 1 skeleton in the room");
            roomB = new Room("Room B", false, false, "combat room", "A room with loud laughing and growling sounds",
                "There is 1 goblin in the room");
            roomC = new Room("Room C", false, true, "mini boss room", "A room made of cobblestone with a huge door",
                "There is a mini boss in the room");
            finalRoom = new Room("Final Room", false, true, "boss room", "A room surrounded by a pool of lava",
                "There is 1 dragon boss in the room");
            goblin = new Monster("Goblin", 50, 10, "Regular", "Sword Attack", 20);
            skeleton = new Monster("Skeleton", 60, 20, "Regular", "Bow and Arrow Attack", 30);
            ogre = new Monster("Ogre", 80, 50, "Mini Boss", "Punch Attack", 40);
            dragon = new Monster("Dragon", 95, 75, "Boss", "Fire Breath Attack", 60);
            healthPotion = new Heals("Health Potion", "This item increases health points", 1, "Heal item", 80);
            sword = new Melee("Sword", "This is a melee item", 10, "Melee item", "Fire effect", 20);
            axe = new Melee("Axe", "This is a melee item", 15, "Melee item", "No effect", 30);
            fireBall = new LongRange("Fire Ball", "This is a long range item", 3, "Long Range item",
                10, 3);
            bowAndArrow = new LongRange("Bow And Arrow", "This is a long range item", 10, "Long Range item",
                5, 5);
            playerInventory = new Inventory();
            monsterInventory = new Inventory();
            statistics = new Statistics(player.NumberOfCoins);
        }

        public void Start()
        {
            bool playing = false;

            playing = true;
            while (playing == true)
            {
                startingRoom.EnterRoom();
                sword.Collected();
                playerInventory.AddItem($"{sword.ItemName}", $"{sword.ItemType}");
                playerInventory.AddItem($"{healthPotion.ItemName}", $"{healthPotion.ItemType}");

                Console.WriteLine($"There are 3 doors in front of you, enter one of the following keys \n" +
                    $"Room A: A\n" +
                    $"Room B: B\n" +
                    $"Room C: C\n");

                bool choosingRoom = true;
                while (choosingRoom == true)
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "A")
                    {
                        roomA.EnterRoom();


                        if (skeletonDead == true)
                        {
                            Console.WriteLine("Please choose room B or C");
                            continue;
                        }

                        bool battle = true;
                        while (battle == true)
                        {
                            string userInput2 = Console.ReadLine();
                            if (userInput2 == "X" || userInput2 == "x")
                            {
                                player.Attack(skeleton, sword.ItemDamage);
                                if (skeleton.Health <= 0)
                                {
                                    player.GainXP(50);
                                    player.PickUpCoins(true, skeleton.NumberOfCoins);
                                    Console.WriteLine($"There is a {fireBall.ItemName} on the ground");
                                    playerInventory.AddItem(fireBall.ItemName, fireBall.ItemType);
                                    Console.WriteLine($"Would you like to use {healthPotion.ItemName}\n" +
                                        $"press H to use {healthPotion.ItemName}");
                                    string userInput3 = Console.ReadLine();
                                    if (userInput3 == "h" || userInput3 == "H")
                                    {
                                        playerInventory.GetItemType(healthPotion.ItemType);
                                        Console.WriteLine($"Healing by {healthPotion.HealthIncrease}...");
                                        player.Health += healthPotion.HealthIncrease;
                                        if (player.Health > 100)
                                        {
                                            player.Health = 100;
                                        }
                                        Console.WriteLine($"{player.Name} current health is {player.Health}");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You did not heal");
                                    }

                                    Console.WriteLine($"Please choose the next room to enter \n" +
                                        $"Room B: B\n" +
                                        $"Room C: C");
                                    skeletonDead = true;
                                    battle = false;
                                    break;
                                }
                                else
                                {
                                    skeleton.Attack(player, skeleton.MonsterStrength);
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{player.Name} did not attack");
                                skeleton.Attack(player, skeleton.MonsterStrength);
                                if (player.Health <= 0)
                                {
                                    choosingRoom = false;
                                    playing = false;
                                    break;
                                }
                            }

                        }



                    }
                    else if (userInput == "B")
                    {
                        roomB.EnterRoom();
                        if (goblinDead == true)
                        {
                            Console.WriteLine("Please choose room A or C");
                            continue;
                        }

                        bool battle = true;
                        while (battle == true)
                        {
                            string userInput2 = Console.ReadLine();
                            if (userInput2 == "X" || userInput2 == "x")
                            {
                                player.Attack(goblin, fireBall.ItemDamage);
                                if (goblin.Health <= 0)
                                {
                                    roomC.UnlockRoom();
                                    player.GainXP(50);
                                    player.PickUpCoins(true, goblin.NumberOfCoins);
                                    Console.WriteLine($"There is a {bowAndArrow.ItemName} on the ground");
                                    playerInventory.AddItem(bowAndArrow.ItemName, bowAndArrow.ItemType);
                                    Console.WriteLine($"Would you like to use {healthPotion.ItemName}\n" +
                                        $"press H to use {healthPotion.ItemName}");
                                    string userInput3 = Console.ReadLine();
                                    if (userInput3 == "h" || userInput3 == "H")
                                    {
                                        playerInventory.GetItemType(healthPotion.ItemType);
                                        playerInventory.GetItemType(healthPotion.ItemType);
                                        Console.WriteLine($"Healing by {healthPotion.HealthIncrease}...");
                                        player.Health += healthPotion.HealthIncrease;
                                        if (player.Health > 100)
                                        {
                                            player.Health = 100;
                                        }
                                        Console.WriteLine($"{player.Name} current health is {player.Health}");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You did not heal");
                                    }
                                    Console.WriteLine($"{roomC} has unlocked");
                                    Console.WriteLine($"Please choose the next room to enter \n" +
                                        $"Room A: A\n" +
                                        $"Room C: C");
                                    goblinDead = true;
                                    battle = false;

                                    break;
                                }
                                else
                                {
                                    goblin.Attack(player, goblin.MonsterStrength);
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{player.Name} did not attack");
                                goblin.Attack(player, goblin.MonsterStrength);
                                if (player.Health <= 0)
                                {
                                    choosingRoom = false;
                                    playing = false;
                                    break;
                                }
                            }

                        }
                    }
                    else if (userInput == "C")
                    {
                        roomC.EnterRoom();

                        if (ogreDead == true)
                        {
                            Console.WriteLine("Please choose room A or C");
                            continue;
                        }

                        bool battle = true;
                        while (battle == true)
                        {
                            string userInput2 = Console.ReadLine();
                            if (userInput2 == "X" || userInput2 == "x")
                            {
                                player.Attack(ogre, bowAndArrow.ItemDamage);
                                if (ogre.Health <= 0)
                                {
                                    player.GainXP(50);
                                    player.PickUpCoins(true, ogre.NumberOfCoins);
                                    Console.WriteLine($"Would you like to use {healthPotion.ItemName}\n" +
                                        $"press H to use {healthPotion.ItemName}");
                                    string userInput3 = Console.ReadLine();
                                    if (userInput3 == "h" || userInput3 == "H")
                                    {
                                        playerInventory.GetItemType(healthPotion.ItemType);
                                        Console.WriteLine($"Healing by {healthPotion.HealthIncrease}...");
                                        player.Health += healthPotion.HealthIncrease;
                                        if (player.Health > 100)
                                        {
                                            player.Health = 100;
                                        }
                                        Console.WriteLine($"{player.Name} current health is {player.Health}");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You did not heal");
                                    }
                                    finalRoom.UnlockRoom();
                                    Console.WriteLine($"You can now enter the final room, press E to enter");
                                    ogreDead = true;
                                    battle = false;

                                    break;
                                }
                                else
                                {
                                    ogre.Attack(player, ogre.MonsterStrength);
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{player.Name} did not attack");
                                ogre.Attack(player, ogre.MonsterStrength);
                                if (player.Health <= 0)
                                {
                                    choosingRoom = false;
                                    playing = false;
                                    break;
                                }
                            }

                        }
                    }


                    else if (userInput == "E")
                    {
                        finalRoom.EnterRoom();
                        if (dragonDead == true)
                        {
                            Console.WriteLine("Gaame over");
                        }

                        bool battle = true;
                        while (battle == true)
                        {
                            string userInput2 = Console.ReadLine();
                            if (userInput2 == "X" || userInput2 == "x")
                            {



                                player.Attack(dragon, axe.ItemDamage);
                                if (dragon.Health <= 0)
                                {
                                    player.GainXP(50);
                                    player.PickUpCoins(true, dragon.NumberOfCoins);
                                    dragonDead = true;
                                    statistics.CalculateAverageCoins(goblin.NumberOfCoins, skeleton.NumberOfCoins,
                                        ogre.NumberOfCoins, dragon.NumberOfCoins, player.NumberOfCoins);

                                    choosingRoom = false;
                                    playing = false;
                                    break;
                                }
                                else
                                {
                                    dragon.Attack(player, dragon.MonsterStrength);
                                }
                            }

                            else
                            {
                                Console.WriteLine($"{player.Name} did not attack");
                                dragon.Attack(player, dragon.MonsterStrength);
                                if (player.Health <= 0)
                                {
                                    choosingRoom = false;
                                    playing = false;
                                    break;
                                }
                            }
                        }
                    }


                    else
                    {
                        Console.WriteLine("Please choose an appropriate room");
                    }

                    if (player.Health <= 0)
                    {
                        statistics.CalculateAverageCoins(goblin.NumberOfCoins, skeleton.NumberOfCoins,
                                        ogre.NumberOfCoins, dragon.NumberOfCoins, player.NumberOfCoins);
                        playing = false;
                    }


                }



                break;
            }
        }
    }


}