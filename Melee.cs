using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Melee : Item, ICollectible
    {
       
        public string ItemEffect { get; set; }
        public int ItemDamage { get; set; }
        public Melee(string itemName, string itemDescription,
            int itemDurability, string itemType, string itemEffect, int itemDamage) :
            base(itemName, itemDescription, itemDurability, itemType)
        {
            ItemEffect = itemEffect;
            ItemDamage = itemDamage;
        }

        public void Collected()
        {
            Console.WriteLine($"{ItemName} can do {ItemDamage} damage");
            Console.WriteLine($"There is a {ItemName} on the ground, press any key to pick it up");
        }
    }
}
