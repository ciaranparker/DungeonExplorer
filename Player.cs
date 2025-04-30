using System;
using System.Collections.Generic;
using System.Configuration;

namespace DungeonExplorer
{
    public class Player : Creatures, IDamagable
    {
        public int NumberOfRoomsEntered { get; set; }
        public int PlayerXp { get; set; }
        public int PlayerLevel { get; set; }


        public Player(string name, int health, int numberOfCoins, int numberOfRoomsEntered, int playerXp, int playerLevel)
            : base(name, health, numberOfCoins) 
        {
            NumberOfRoomsEntered = numberOfRoomsEntered;
            PlayerXp = playerXp;
            PlayerLevel = playerLevel;
        }

        public void Damaged(int damageTaken)
        {
            Health -= damageTaken;
            Console.WriteLine($"{Name} has taken {damageTaken} damage");
            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} has reached {Health} health. You have died");
                Console.WriteLine($"You had {NumberOfCoins} coins");
                Console.WriteLine($"You had {PlayerXp} XP");
            }
            Console.WriteLine($"{Name} current health is {Health}");
        }

        public override void Attack(IDamagable attacked, int damageTaken)
        {
            if (attacked is Creatures target)
            {
                Console.WriteLine($"{Name} has attacked {target.Name}");
            }
            
            attacked.Damaged(damageTaken);
        }

        public override void Defense(bool defended, int damage, int damageReduction, int damageTaken)
        {
            if (defended == true)
            {
                Console.WriteLine($"{Name} has defended \n" +
                    $"{damage} reduced by {damageReduction}");
                damageTaken = damage - damageReduction;
            }

            else
            {
                Console.WriteLine($"{Name} has not defended");
            }
        }

        public override void PickUpCoins(bool pickingUpCoins, int coins)
        {
            if (pickingUpCoins = true)
            {
                NumberOfCoins += coins;
                Console.WriteLine($"{Name} now has {coins} coins");
            }
        }

        public void GainXP(int XP)
        {
            PlayerXp += XP;
            Console.WriteLine($"{Name} now has {XP} XP");
        }
    }
}