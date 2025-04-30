using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    abstract class Item
    {
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public int ItemDurability { get; set; }
        public string ItemType { get; private set; }
        public int ItemSpace { get; private set; }

        public Item(string itemName, string itemDescription, int itemDurability, string itemType)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemDurability = itemDurability;
            ItemType = itemType;
        }

        
    }
}
