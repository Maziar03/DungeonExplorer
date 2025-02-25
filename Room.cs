namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public string NextRoom { get; private set; }
        public bool HasEnemy { get; set; }

        public Room(string description, string nextRoom = null, bool hasEnemy = false)
        {
            this.description = description;
            NextRoom = nextRoom;
            HasEnemy = hasEnemy;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
