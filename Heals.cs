using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Heals : Item, ICollectible
    {
        public int HealthIncrease { get; set; }

        public Heals(string itemName, string itemDescription, 
            int itemDurability, string itemType, int healthIncrease) :
            base(itemName, itemDescription, itemDurability, itemType)
        {
            HealthIncrease = healthIncrease;
        }

        public void Collected()
        {
            Console.WriteLine($"{ItemName}s can heal by {HealthIncrease}");
            Console.WriteLine($"There is a {ItemName} on the ground, press X to pick it up");
        }

    }
}
