using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Inventory
    {
        private Dictionary<string, string> inventoryItems;

        public Inventory()
        {
            inventoryItems = new Dictionary<string, string>();
        }

        public Dictionary<string, string> GetItemType(string itemType)
        {
            Dictionary<string, string> ItemsToReturn = new Dictionary<string, string>();
            foreach (var item in inventoryItems)
            {
                if (item.Value == itemType)
                {
                    ItemsToReturn.Add(item.Key, item.Value);
                }
            }
            return ItemsToReturn;

        }
        

        public void AddItem(string itemName, string itemType)
        {
            Console.ReadKey();
            inventoryItems.Add(itemName, itemType);
            Console.WriteLine($"{itemName} has been added to inventory");
        }

        public void RemoveItem(string itemName)
        {
            inventoryItems.Remove(itemName);
            Console.WriteLine($"{itemName} has been removed from inventory");
        }

        public string InventoryContents()
        {
            return string.Join(", ", inventoryItems);
        }
    }
}
