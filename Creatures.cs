using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creatures
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int NumberOfCoins { get; set; }

        public Creatures(string name, int health, int numberOfCoins)
        {
            Name = name;
            Health = health;
            NumberOfCoins = numberOfCoins;
        }

        public abstract void PickUpCoins(bool pickingUpCoins, int coins);
        public abstract void Attack(IDamagable attacked, int damageTaken);
        public abstract void Defense(bool defended, int damage, int damageReduction, int damageTaken);
    }
}
