using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        public Game()
        {
            // Initialize the game with one room and one player

            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);
            currentRoom = new Room("A dark and spooky chamber with a flickering torch struggling to stay lit.");
            Console.WriteLine("\nWelcome, " + player.Name + "! You enter the dungeon...");

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            playing = true;
            while (playing)
            {
                Console.WriteLine("\n*** Choose one of these options ***");
                Console.WriteLine("1. View Room Info");
                Console.WriteLine("2. Pick Up an Item");
                Console.WriteLine("3. Check Status");
                Console.WriteLine("4. Exit Game");
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
                    Console.WriteLine("\nRoom Info: " + currentRoom.GetDescription());
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
                    Console.WriteLine("\nExiting now... See you soon!");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Error!Make sure to enter a valid choice");
                    break;

            }
        }
    }
}