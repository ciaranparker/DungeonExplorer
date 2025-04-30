using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Monster : Creatures, IDamagable
    {
        public string MonsterType { get; private set; }
        public string MonsterAttackType { get; private set; }
        public int MonsterStrength { get; set; }

        public Monster(string name, int health, int numberOfCoins, string monsterType, string monsterAttackType,
            int monsterStrength) : base(name, health, numberOfCoins)
        {
            MonsterType = monsterType;
            MonsterAttackType = monsterAttackType;
            MonsterStrength = monsterStrength;
        }

        public void Damaged(int damageTaken)
        {
            if (MonsterType == "Regular" && Name == "Skeleton")
            {
                damageTaken = 30;
            }

            else if (MonsterType == "Regular" && Name == "Goblin")
            {
                damageTaken = 20;
            }

            else if (MonsterType == "Mini Boss")
            {
                damageTaken = 40;
            }

            else if (MonsterType == "Boss")
            {
                damageTaken = 60;
            }
            Health -= damageTaken;


            bool playerDead = false;

            Console.WriteLine($"{Name} has taken {damageTaken} damage \n" +
                    $"{Name}'s current health is: {Health}");

            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} has reached {Health} health");
                Console.WriteLine($"{Name} has dropped {NumberOfCoins} coins");
            }
        }

        public override void Attack(IDamagable attacked, int damageTaken)
        {
            Console.WriteLine($"{Name} has used {MonsterAttackType} attack");
            attacked.Damaged(damageTaken);
        }

        public override void Defense(bool defended, int damage, int damageReduction, int damageTaken)
        {
            if (MonsterType == "Regular")
            {
                Random regularRandom = new Random();
                int randomNum = regularRandom.Next(1, 10);
                if (randomNum == 1)
                {
                    defended = true;
                }
                else
                {
                    defended = false;
                }
            }

            else if (MonsterType == "Mini Boss")
            {
                Random regularRandom = new Random();
                int randomNum = regularRandom.Next(1, 4);
                if (randomNum == 1)
                {
                    defended = true;
                }
                else
                {
                    defended = false;
                }
            }

            else if (MonsterType == "Boss")
            {
                Random regularRandom = new Random();
                int randomNum = regularRandom.Next(1, 2);
                if (randomNum == 1)
                {
                    defended = true;
                }
                else
                {
                    defended = false;
                }
            }

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
    }
}
