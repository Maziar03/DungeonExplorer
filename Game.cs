using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    using System;
    using System.Collections.Generic;

    namespace DungeonExplorer
    {
        internal class Game
        {
            private Player player;
            private Dictionary<string, Room> rooms;
            private Room currentRoom;
            private bool playing;

            public Game()
            {
                Console.Write("Enter your player name: ");
                string playerName = Console.ReadLine();
                player = new Player(playerName, 100);

                rooms = new Dictionary<string, Room>
            {
                { "Entrance", new Room("A dark, eerie chamber with a flickering torch on the wall.", "Hallway") },
                { "Hallway", new Room("A long corridor with damp walls. There's a faint sound ahead.", "Treasure Room") },
                { "Treasure Room", new Room("A glittering chamber filled with gold and a guarding monster!", null, true) }
            };

                currentRoom = rooms["Entrance"];
                Console.WriteLine($"\nWelcome, {player.Name}! You enter the dungeon...");
            }

            public void Start()
            {
                playing = true;
                while (playing)
                {
                    Console.WriteLine("\n--- What would you like to do? ---");
                    Console.WriteLine("1. View Room Description");
                    Console.WriteLine("2. Pick Up an Item");
                    Console.WriteLine("3. Check Player Status");
                    Console.WriteLine("4. Move to Next Room");
                    Console.WriteLine("5. Fight Monster");
                    Console.WriteLine("6. Exit Game");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();
                    HandleChoice(choice);
                }
            }

            private void HandleChoice(string choice)
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nRoom Description: " + currentRoom.GetDescription());
                        break;
                    case "2":
                        Console.Write("Enter item to pick up: ");
                        string item = Console.ReadLine();
                        player.PickUpItem(item);
                        break;
                    case "3":
                        Console.WriteLine("\nPlayer Status:");
                        Console.WriteLine("Name: " + player.Name);
                        Console.WriteLine("Health: " + player.Health);
                        Console.WriteLine("Inventory: " + (player.InventoryContents() == "" ? "Empty" : player.InventoryContents()));
                        break;
                    case "4":
                        MoveToNextRoom();
                        break;
                    case "5":
                        if (currentRoom.HasEnemy)
                            StartCombat();
                        else
                            Console.WriteLine("\nThere's no monster here!");
                        break;
                    case "6":
                        Console.WriteLine("\nExiting the game... Goodbye!");
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option.");
                        break;
                }
            }

            private void MoveToNextRoom()
            {
                if (currentRoom.HasEnemy)
                {
                    Console.WriteLine("\nA monster blocks your path! Defeat it first.");
                    return;
                }

                if (string.IsNullOrEmpty(currentRoom.NextRoom))
                {
                    Console.WriteLine("\nThere is no exit. You have reached the end of the dungeon!");
                    return;
                }

                if (rooms.ContainsKey(currentRoom.NextRoom))
                {
                    currentRoom = rooms[currentRoom.NextRoom];
                    Console.WriteLine("\nYou move to the next room...");
                }
            }


            private void StartCombat()
            {
                Console.WriteLine("\nA monster appears! Prepare to fight!");
                int monsterHealth = 50;

                while (player.Health > 0 && monsterHealth > 0)
                {
                    Console.WriteLine("\nChoose an action:");
                    Console.WriteLine("1. Attack");
                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.WriteLine("You attack the monster! It takes 20 damage.");
                        monsterHealth -= 20;

                        if (monsterHealth > 0)
                        {
                            Console.WriteLine("The monster attacks back! You take 10 damage.");
                            player.TakeDamage(10);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. You must fight!");
                    }
                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("\nYou have been defeated! Game over.");
                    playing = false;
                }
                else if (monsterHealth <= 0)
                {
                    Console.WriteLine("\nYou defeated the monster! The path is clear.");
                    currentRoom.HasEnemy = false;
                }
            }
        }
    }
}
