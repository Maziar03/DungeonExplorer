using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine("You picked up: " + item);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"You have {Health} health remaining.");
        }

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}