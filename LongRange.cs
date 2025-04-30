using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class LongRange : Item, ICollectible
    {
        public int ItemDamage { get; set; }
        public int AmmoNumber { get; set; }
        
        public LongRange(string itemName, string itemDescriptiom,
            int itemDurability, string itemType,int itemDamage, int ammoNumber) :
            base(itemName, itemDescriptiom, itemDurability, itemType)
        {
            ItemDamage = itemDamage;
            AmmoNumber = ammoNumber;
            
        }

        public void Collected()
        {
            Console.WriteLine($"{ItemName}s can do {ItemDamage}");
            Console.WriteLine($"There is a {ItemName} on the ground, press X to pick it up");
        }


    }
}
